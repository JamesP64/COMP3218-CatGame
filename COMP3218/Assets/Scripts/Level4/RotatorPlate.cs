using UnityEngine;

public class RotatorPlate : MonoBehaviour
{
    // Graphics
    public Sprite downSprite;
    public Sprite upSprite;
    public SpriteRenderer spriteRenderer;

    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.sprite = downSprite;
            gameController.rotatorPlatePressed();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite = upSprite;
    }
}
