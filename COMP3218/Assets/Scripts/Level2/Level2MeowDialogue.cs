using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Rendering.Universal;
using System;

public class Level2MeowDialogue : MonoBehaviour
{
    public GameObject speechBubble;
    public float displayDuration = 2f;
    public float activationRadius = 5f;
    public LayerMask lightGroupLayer;
    public GameObject gameLogic;

    private GameObject activeBubble;
    private AudioSource audioData;
    private GameLogic logic;

    public GameObject safeZone1;
    public GameObject safeZone2;
    public GameObject safeZone3;

    public GameObject pressurePlate;

    public GameObject eyeLightsLeftPosition1;
    public GameObject eyeLightsLeftPosition2;
    public GameObject eyeLightsTop;

    public GameObject PinkMaker;

    private Boolean eyeLightsLeftOn; 
    private Boolean eyeLightsTopOn;

    // to win, eyelightstop need to be on, eyeligtsleft pos1

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        logic = gameLogic.GetComponent<GameLogic>();
        eyeLightsLeftOn = false;
        eyeLightsTopOn = false;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowSpeechBubble();
            audioData.Play(0);
            ActivateNearbyLights();
        }
        if (eyeLightsLeftOn && eyeLightsTopOn)
        {
            PinkMaker.SetActive(true);
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
        Debug.Log($"Found {hits.Length} nearby light groups");

        foreach (var hit in hits)
        {
            var group = hit.transform.parent != null ? hit.transform.parent.gameObject : hit.gameObject;
            var eyes = group.transform.Find("Eyes");
            if (eyes == null) continue;

            Debug.Log($"Activating light group: {group.name}");

          
            if (group.name == "EyeLightsTop" && !eyes.gameObject.activeSelf)
            {
                safeZone1.SetActive(true);
                eyes.gameObject.SetActive(true);
                StartCoroutine(FadeInLights(eyes.gameObject));
                eyeLightsTopOn = true;
                UpdateWin();
                Debug.Log("Win condition: " + logic.getWin());
            }

            else if (group.name.Contains("EyeLightsLeft"))
            {
                HandleStatueControlledLights();
                PDetect.statueOn();
            }
        }
    }

    public void HandleStatueControlledLights()
    {
       
        bool lookingRight = PDetect.LookingRight;

        var rightEyes = eyeLightsLeftPosition1.transform.Find("Eyes").gameObject;
        var downEyes = eyeLightsLeftPosition2.transform.Find("Eyes").gameObject;

        
        if (lookingRight)
        {
            if (!rightEyes.activeSelf)
            {
                Debug.Log("Statue looking right: activating right beam.");
                safeZone2.SetActive(true);
                safeZone3.SetActive(false);
                downEyes.SetActive(false);
                rightEyes.SetActive(true);
                StartCoroutine(FadeInLights(rightEyes));
                eyeLightsLeftOn = false;
                UpdateWin();
                Debug.Log("Win condition: " + logic.getWin());

            }
        }
        else
        {
            if (!downEyes.activeSelf)
            {
                Debug.Log("Statue looking down: activating down beam.");
                safeZone3.SetActive(true);
                safeZone2.SetActive(false);
                rightEyes.SetActive(false);
                downEyes.SetActive(true);
                StartCoroutine(FadeInLights(downEyes));
                eyeLightsLeftOn = true;
                UpdateWin();
                Debug.Log("Win condition: " + logic.getWin());

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
    }

    // to win, eyelightstop need to be on, eyeligtsleft pos1
    void UpdateWin()
    {
        Debug.Log("Updating win condition, top lights: " + eyeLightsTopOn + ", left lights: " + eyeLightsLeftOn);
        if(eyeLightsTop.activeSelf && eyeLightsLeftPosition1.activeSelf)
        {
            logic.setWin(true);
        }
        else
        {
            logic.setWin(false);
        }
    }
}
