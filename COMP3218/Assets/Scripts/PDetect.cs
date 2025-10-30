using UnityEngine;
using UnityEngine.SceneManagement;

public class PDetect : MonoBehaviour
{

    public GameObject statue1;
    public GameObject statue2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (statue1.activeSelf)
            {
                statue1.SetActive(false);
                statue2.SetActive(true);
            }
            else
            {
                statue2.SetActive(false);
                statue1.SetActive(true);
            }
        }

        Debug.Log(collision);
    }
}
