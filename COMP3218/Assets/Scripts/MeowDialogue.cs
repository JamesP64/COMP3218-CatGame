using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class MeowDialogue : MonoBehaviour
{
    public GameObject speechBubble;
    public float displayDuration = 2f;
    public float activationRadius = 5f;
    public LayerMask lightGroupLayer;
    public GameObject gameLogic;

    private GameObject activeBubble;
    private AudioSource audioData;
    private GameLogic logic;

    public GameObject safeZone;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        logic = gameLogic.GetComponent<GameLogic>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowSpeechBubble();
            audioData.Play(0);
            ActivateNearbyLights();
        }
    }

    void ShowSpeechBubble()
    {
        if (activeBubble != null) Destroy(activeBubble);
        activeBubble = Instantiate(speechBubble, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        activeBubble.transform.SetParent(transform);
        Destroy(activeBubble, displayDuration);
    }

    void ActivateNearbyLights()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, activationRadius, lightGroupLayer);
        foreach (var hit in hits)
        {
            var group = hit.transform.parent != null ? hit.transform.parent.gameObject : hit.gameObject;
            var eyes = group.transform.Find("Eyes");
            if (eyes != null && !eyes.gameObject.activeSelf)
            {
                safeZone.gameObject.SetActive(true);
                eyes.gameObject.SetActive(true);
                StartCoroutine(FadeInLights(eyes.gameObject));
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, activationRadius);
    }

    IEnumerator FadeInLights(GameObject eyes)
    {
        var lights = eyes.GetComponentsInChildren<Light2D>(true);
        foreach (var l in lights) l.enabled = true;

        float duration = 1.2f;
        float t = 0f;
        var lightData = new (Light2D light, float targetFalloff)[lights.Length];

        for (int i = 0; i < lights.Length; i++)
        {
            lightData[i] = (lights[i], lights[i].shapeLightFalloffSize);
            lights[i].shapeLightFalloffSize = 0f;
            lights[i].intensity = 0f;
        }

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / duration);
            foreach (var data in lightData)
            {
                if (data.light.lightType == Light2D.LightType.Parametric)
                    data.light.intensity = Mathf.Lerp(0f, 3f, normalized);
                else if (data.light.lightType == Light2D.LightType.Freeform)
                {
                    data.light.intensity = Mathf.Lerp(0f, 1f, normalized * 1.2f);
                    data.light.shapeLightFalloffSize = Mathf.Lerp(0f, data.targetFalloff, normalized);
                }
            }
            yield return null;
        }

        foreach (var data in lightData)
        {
            data.light.intensity = data.light.lightType == Light2D.LightType.Parametric ? 3f : 1f;
            data.light.shapeLightFalloffSize = data.targetFalloff;
        }

        logic.setWin(true);
        Debug.Log("Set win to true");
    }
}
