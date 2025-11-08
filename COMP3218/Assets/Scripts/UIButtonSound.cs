using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIButtonSound : MonoBehaviour
{
    [SerializeField] public AudioClip hoverSound;
    [SerializeField] public AudioClip clickSound;
    [SerializeField] public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlayClickSound);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
