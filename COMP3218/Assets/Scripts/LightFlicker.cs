using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [Header("Light Target")]
    public Light2D light2D;

    [Header("Flicker Settings")]
    public float baseIntensity = 1.0f;  
    public float flickerAmount = 0.3f;  
    public float flickerSpeed = 5f;     

    float noiseSeed;

    void Start()
    {
        if (light2D == null)
            light2D = GetComponent<Light2D>();

        noiseSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(noiseSeed, Time.time * flickerSpeed);
        float intensity = baseIntensity + (noise - 0.5f) * flickerAmount;
        light2D.intensity = Mathf.Clamp(intensity, 0f, 10f);
        light2D.pointLightOuterRadius = 3f + (noise - 0.5f) * 0.3f;
    }
}
