using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.Rendering.Universal;
using System;

public class Level3MeowDialogue : MonoBehaviour
{
    public GameObject speechBubble;
    public float displayDuration = 2f;
    public float activationRadius = 5f;
    public LayerMask lightGroupLayer;
    public GameObject gameLogic;
    public GameObject eyeLightsLeft;
    public GameObject eyeLightsTop;

    private GameObject activeBubble;
    private AudioSource audioData;
    private GameLogic logic;

    public GameObject boxPos1Light;
    public GameObject boxPos2Light;

    public GameObject boxPos1SafeZoneNotOccluded;
    public GameObject boxPos2SafeZoneNotOccluded;
    public GameObject boxPos1SafeZoneOccluded;
    public GameObject boxPos2SafeZoneOccluded;

    public GameObject boxPos1;
    public GameObject boxPos2;

    private Boolean lightsTopOn;
    private Boolean lightsLeftOn;
    private Boolean boxIsPos2;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        logic = gameLogic.GetComponent<GameLogic>();
        lightsTopOn = false;
        lightsLeftOn = false;
        boxIsPos2 = false;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowSpeechBubble();
            audioData.Play(0);
            ToggleNearbyLights();
            // check win condition
            UpdateWin();
        }
    }

    void ShowSpeechBubble()
    {
        if (activeBubble != null) Destroy(activeBubble);
        activeBubble = Instantiate(speechBubble, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        activeBubble.transform.SetParent(transform);
        Destroy(activeBubble, displayDuration);
    }

    // to win, need EyeLightsTop to be on and EyeLightsLeft to be on, and BoxPosition2 to be active
    // since toggleNearbyLights is called in update, can check here also for box position
    void ToggleNearbyLights()
    {
        // update BoxPosition
        if (boxPos1.activeSelf)
        {
            boxIsPos2 = false;
        }
        if (boxPos2.activeSelf)
        {
            boxIsPos2 = true;
        }


        var hits = Physics2D.OverlapCircleAll(transform.position, activationRadius, lightGroupLayer);
        foreach (var hit in hits)
        {
            var group = hit.transform.parent != null ? hit.transform.parent.gameObject : hit.gameObject;
            var eyes = group.transform.Find("Eyes");
            if (eyes == null) continue;

            if (group.name == "EyeLightsTop")
            {
                ToggleEyeLight(eyes.gameObject);

                // set the top lights to be true/false using the game objects state
                lightsTopOn = eyes.gameObject.activeSelf;

                if (boxPos1.activeSelf)
                {
                    boxPos1Light.SetActive(true);
                    boxPos1SafeZoneOccluded.SetActive(true);
                }
                else
                {
                    boxPos1SafeZoneNotOccluded.SetActive(true);
                }
            }
            else if (group.name == "EyeLightsLeft")
            {
                ToggleEyeLight(eyes.gameObject);

                // set the left lights to be true/false using the game objects state
                lightsLeftOn = eyes.gameObject.activeSelf;

                if (boxPos2.activeSelf)
                {
                    boxPos2Light.SetActive(true);
                    boxPos2SafeZoneOccluded.SetActive(true);
                }
                else
                {
                    boxPos2SafeZoneNotOccluded.SetActive(true);
                }
            }

        }
    }
    void ToggleEyeLight(GameObject eyes)
    {
        bool currentlyActive = eyes.activeSelf;
        eyes.SetActive(!currentlyActive);
        if (!currentlyActive) StartCoroutine(FadeInLights(eyes));
        else StartCoroutine(FadeOutLights(eyes));
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
    }

    IEnumerator FadeOutLights(GameObject eyes)
    {
        var lights = eyes.GetComponentsInChildren<Light2D>(true);
        float duration = 0.8f;
        float t = 0f;
        var startValues = new (Light2D light, float startFalloff, float startIntensity)[lights.Length];

        for (int i = 0; i < lights.Length; i++)
            startValues[i] = (lights[i], lights[i].shapeLightFalloffSize, lights[i].intensity);

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / duration);
            foreach (var data in startValues)
            {
                data.light.intensity = Mathf.Lerp(data.startIntensity, 0f, normalized);
                data.light.shapeLightFalloffSize = Mathf.Lerp(data.startFalloff, 0f, normalized);
            }
            yield return null;
        }

        foreach (var data in startValues)
        {
            data.light.intensity = 0f;
            data.light.enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, activationRadius);
    }

    void UpdateWin()
    {
        if (lightsTopOn && lightsLeftOn && boxIsPos2)
        {
            logic.setWin(true);
        } else
        {
            Debug.Log("LightsTop: " + lightsTopOn);
            Debug.Log("LightsLeft: " + lightsLeftOn);
            Debug.Log("Box is pos2: " + boxIsPos2);
        }

    }
}
