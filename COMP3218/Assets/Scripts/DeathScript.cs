using UnityEngine;
public class DeathScript : MonoBehaviour
{

    private int safeZoneCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SafeZone"))
            safeZoneCount++;
            Debug.Log(safeZoneCount);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SafeZone"))
            safeZoneCount--;
            Debug.Log(safeZoneCount);
    }

    void Update()
    {
        if (safeZoneCount <= 0)
        {
            Debug.Log("Die");
            transform.position = Vector3.zero;
            var rb = GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }

}
