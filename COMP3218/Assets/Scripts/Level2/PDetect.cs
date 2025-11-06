using UnityEngine;
using UnityEngine.SceneManagement;

public class PDetect : MonoBehaviour
{

    public GameObject statueLookingDown;
    public GameObject statueLookingRight;

    public static bool LookingRight = false;

    public Level2MeowDialogue dialogue;

    public static bool leftStatueOn = false;


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
            if (statueLookingDown.activeSelf)
            {
                statueLookingDown.SetActive(false);
                statueLookingRight.SetActive(true);
                LookingRight = true;
            }
            else
            {
                statueLookingRight.SetActive(false);
                statueLookingDown.SetActive(true);
                LookingRight = false;
            }

            if (leftStatueOn)
            {
                dialogue.HandleStatueControlledLights();
            }
            
        }
    }

    public static void statueOn()
    {
        leftStatueOn = true;    
    }
}
