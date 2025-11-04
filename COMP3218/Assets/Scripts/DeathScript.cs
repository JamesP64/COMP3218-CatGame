using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{

    private int safeZoneCount = 0;
    public string loseScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SafeZone"))
            safeZoneCount++;
            Debug.Log("Safe zone count: " + safeZoneCount);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SafeZone"))
            safeZoneCount--;
            Debug.Log("Safe zone count: " + safeZoneCount);
    }

    void Update()
    {
        if (safeZoneCount <= 0)
        {
            Debug.Log("Die");

            SceneManager.LoadScene(loseScene, LoadSceneMode.Single);

            
            //transform.position = Vector3.zero;
            //var rb = GetComponent<Rigidbody2D>();
            //if (rb != null)
            //    rb.linearVelocity = Vector2.zero;
            
        }
    }

}
