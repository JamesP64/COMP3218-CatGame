using System.Collections;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int top;
    public int bottom;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool goingUp;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveInput = Vector2.zero;
    }

    public void Update()
    {
        moveInput = Vector2.zero;
        if(rb.position.y <= bottom)
        {
            goingUp = true;
        }
        if(rb.position.y >= top)
        {
            goingUp = false;
        }

        if(goingUp)
        {
            moveInput.y += 1;
        }

        if (!goingUp)
        {
            moveInput.y -= 1;
        }

        moveInput = moveInput.normalized;
       
    }


    void FixedUpdate()
    {
        Vector2 newPos = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
        
    }
}
