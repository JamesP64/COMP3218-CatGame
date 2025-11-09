using UnityEngine;

public class RotatorPlate : MonoBehaviour
{
    // Graphics
    public Sprite downSprite;
    public Sprite upSprite;
    public SpriteRenderer spriteRenderer;

    public GameController gameController;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;   
    [SerializeField] private AudioClip platePressSound;
    [SerializeField] private float platePressVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = downSprite;

            if (audioSource != null && platePressSound != null)
            {
                audioSource.PlayOneShot(platePressSound, platePressVolume);
            }

            gameController.rotatorPlatePressed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = upSprite;
    }
}
