using UnityEngine;

public class StarBob : MonoBehaviour
{
    private Rigidbody2D rb;
    public float topY = -3f;
    public float bottomY = -3.5f;
    public float speed = 1f;

    private bool goingUp = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 pos = rb.position;

        if (goingUp)
        {
            pos.y += speed * Time.fixedDeltaTime;
            if (pos.y >= topY) goingUp = false;
        }
        else
        {
            pos.y -= speed * Time.fixedDeltaTime;
            if (pos.y <= bottomY) goingUp = true;
        }

        rb.MovePosition(pos);
    }
}
