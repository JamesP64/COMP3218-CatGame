using UnityEngine;

public class FreezeBox : MonoBehaviour
{

    // Graphics
    public Sprite downSprite;
    public Sprite upSprite;
    public SpriteRenderer spriteRenderer;

    public GameController gameController;
    public Statue linkedStatue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = downSprite;
            gameController.freeze(linkedStatue);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = upSprite;
    }
}
