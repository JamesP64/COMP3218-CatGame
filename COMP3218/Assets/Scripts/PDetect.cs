using UnityEngine;
using UnityEngine.SceneManagement;

public class PDetect : MonoBehaviour
{

    public GameObject statue1;
    public GameObject statue2;

    public static bool LookingRight = true;

    public Level2MeowDialogue dialogue;

    public static bool leftStatueOn;


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
                LookingRight = false;
            }
            else
            {
                statue2.SetActive(false);
                statue1.SetActive(true);
                LookingRight = true;
            }

            if (leftStatueOn)
            {
                dialogue.HandleStatueControlledLights();
            }
            
        }

        Debug.Log(collision);
    }

    public static void statueOn()
    {
        leftStatueOn = true;    
    }
}
