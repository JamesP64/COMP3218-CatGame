using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPulse : MonoBehaviour
{
    public Light2D light2D;
    public float pulseSpeed = 0.6f;
    public float minIntensity = 0.05f;
    public float maxIntensity = 0.3f;
    void Update()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        float t = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;
        light2D.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}

