using UnityEngine;
using static UnityEngine.Rendering.RayTracingAccelerationStructure;

public class RainbowCat : MonoBehaviour
{
    private SpriteRenderer sr;
    private float hue = 0f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (!SkinSettings.IsRainbow)
        {
            enabled = false;
            Debug.Log("Enabled:" + enabled);
        }
    }

    void Update()
    {
        hue += Time.deltaTime * 0.2f;
        if (hue > 1f) hue = 0f;

        Color rainbow = Color.HSVToRGB(hue, 1f, 1f);
        sr.color = rainbow;
    }
}
