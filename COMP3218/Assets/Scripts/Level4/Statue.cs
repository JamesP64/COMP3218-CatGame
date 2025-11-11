using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Statue : MonoBehaviour
{
    public GameObject progressBarObject; 
    private Image fillImage;

    public GameObject lookingDownSprite;
    public GameObject lookingDiagSprite;

    public GameObject lookingDownSafeZone;
    public GameObject lookingDiagSafeZone;

    public GameObject lookingDownLight;
    public GameObject lookingDiagLight;

    private bool activated;
    private bool lookingDown;
    private bool lookingDiag;

    private float freezeTimer = 0f;
    private float freezeDuration = 0f;
    private bool isFrozen = false;

    private SpriteRenderer spriteRendererTop;
    private SpriteRenderer spriteRendererBottom;

    public string defaultState;

    private void Start()
    {
        if (defaultState.Equals("Left"))
        {
            activated = true;
        }else
        {
            activated = false;
        }
 
        if (defaultState.Equals("Down"))
        {
            lookingDown = true;
            lookingDiag = false;
            spriteRendererTop = lookingDownSprite.transform.Find("Top").GetComponent<SpriteRenderer>();
            spriteRendererBottom = lookingDownSprite.transform.Find("Bottom").GetComponent<SpriteRenderer>();
        }
        else
        {
            lookingDown = false;
            lookingDiag = true;
            spriteRendererTop = lookingDiagSprite.transform.Find("Top").GetComponent<SpriteRenderer>();
            spriteRendererBottom = lookingDiagSprite.transform.Find("Bottom").GetComponent<SpriteRenderer>();
        }

        fillImage = progressBarObject.transform.Find("Fill").GetComponent<Image>();
        progressBarObject.SetActive(false);
    }

    private void Update()
    {
        if (isFrozen)
        {
            freezeTimer += Time.deltaTime;
            float t = Mathf.Clamp01(freezeTimer / freezeDuration);

            fillImage.fillAmount = 1f - t;

            if (t >= 1f)
            {
                isFrozen = false;
                progressBarObject.SetActive(false);
            }    
        }
    }
    public void rotate()
    {
        Debug.Log(this.name + "Rotate Called");
        Debug.Log(this.name + " Activated: " + activated);
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

        swapRenderer();
    }

    public void activate()
    {
        Debug.Log(this.name + "Activate Called");
        setActivated(true);
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

    public void freeze (float duration)
    {
        freezeDuration = duration;
        freezeTimer = 0f;
        isFrozen = true;

        if (progressBarObject != null)
        {
            progressBarObject.SetActive(true);
            fillImage.fillAmount = 1f;
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

    private void swapRenderer()
    {
        if (lookingDown)
        {
            spriteRendererTop = lookingDownSprite.transform.Find("Top").GetComponent<SpriteRenderer>();
            spriteRendererBottom = lookingDownSprite.transform.Find("Bottom").GetComponent<SpriteRenderer>();
        }
        else
        {
            spriteRendererTop = lookingDiagSprite.transform.Find("Top").GetComponent<SpriteRenderer>();
            spriteRendererBottom = lookingDiagSprite.transform.Find("Bottom").GetComponent<SpriteRenderer>();
        }
    }

    private void setActivated(bool active)
    {
        Debug.Log("Set Activated Called" + active);
        activated = active;
    }
}
