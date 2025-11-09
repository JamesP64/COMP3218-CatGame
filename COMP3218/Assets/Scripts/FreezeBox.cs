using UnityEngine;

public class FreezeBox : MonoBehaviour
{

    // Graphics
    public Sprite downSprite;
    public Sprite upSprite;
    public SpriteRenderer spriteRenderer;

    public GameController gameController;
    public Statue linkedStatue;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip boxPressSound;
    [SerializeField] private float boxPressVolume = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = downSprite;
            transform.position += new Vector3(0, -0.1f, 0);

            if (audioSource != null && boxPressSound != null)
            {
                audioSource.PlayOneShot(boxPressSound, boxPressVolume);
            }

            gameController.freeze(linkedStatue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = upSprite;
        transform.position += new Vector3(0, 0.1f, 0);
    }
}
