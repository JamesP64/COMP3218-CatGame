using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Statue : MonoBehaviour
{
    public GameObject lookingDownSprite;
    public GameObject lookingDiagSprite;

    public GameObject lookingDownSafeZone;
    public GameObject lookingDiagSafeZone;

    public GameObject lookingDownLight;
    public GameObject lookingDiagLight;

    private static bool activated;
    private static bool lookingDown;
    private static bool lookingDiag;    

    private void Start()
    {
        activated = false;
        lookingDown = true;
        lookingDiag = false;   
    }
    public void rotate()
    {
        Debug.Log(this.name + "Rotate Called"); 
        lookingDownSprite.SetActive(!lookingDownSprite.activeSelf);
        lookingDiagSprite.SetActive(!lookingDiagSprite.activeSelf);
        if (activated)
        {
            lookingDownSafeZone.SetActive(!lookingDownSafeZone.activeSelf);
            lookingDiagSafeZone.SetActive(!lookingDiagSafeZone.activeSelf);
            lookingDownLight.SetActive(!lookingDownLight.activeSelf);
            lookingDiagLight.SetActive(!lookingDiagLight.activeSelf);
        }
       
        lookingDown = !lookingDown;
        lookingDiag = !lookingDiag;
    }

    public void activate()
    {
        activated = true;
        if (lookingDown)
        {
            lookingDownSafeZone.SetActive(true);
            lookingDownLight.SetActive(true);
            StartCoroutine(FadeInLights(lookingDownLight));
        }
        else
        {
            lookingDiagSafeZone.SetActive(true);
            lookingDiagLight.SetActive(true);
            StartCoroutine(FadeInLights(lookingDiagLight));
        }
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
}
