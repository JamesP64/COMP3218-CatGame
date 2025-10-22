using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public BoxCollider2D gameBoundary; 

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private Vector2 playerSize;

    public Animator anim;

    private Vector2 lastMoveDir = Vector2.down;

    private float idleDelay = 0.1f;
    private float idleTimer = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameBoundary != null)
        {
            minBounds = gameBoundary.bounds.min;
            maxBounds = gameBoundary.bounds.max;

            BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
            if (playerCollider != null)
            {
                playerSize = playerCollider.bounds.extents;
            }
            else
            {
                playerSize = Vector2.zero;
            }
        }

        rb.gravityScale = 0; 
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void Update()
    {
        moveInput = Vector2.zero;

        // Movement from the keyboard
        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveInput.y += 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y -= 1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput.x += 1f;

            moveInput = moveInput.normalized;
        }

        // Remembering where you have been moving
        if (moveInput != Vector2.zero)
        {
            lastMoveDir = moveInput;
            idleTimer = 0f;
        } else
        {
            idleTimer += Time.deltaTime;
        }

        // For my animations
        anim.SetFloat("MoveX", lastMoveDir.x);
        anim.SetFloat("MoveY", lastMoveDir.y);
        anim.SetBool("IsMoving", idleTimer < idleDelay);
    }


    void FixedUpdate()
    {
        Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + playerSize.x, maxBounds.x - playerSize.x);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + playerSize.y, maxBounds.y - playerSize.y);

        rb.MovePosition(newPos);
    }
}
