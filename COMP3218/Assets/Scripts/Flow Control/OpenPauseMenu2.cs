using UnityEngine;
using UnityEngine.InputSystem;

public class OpenPauseMenu2 : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject cat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            pauseMenu.SetActive(true);
            cat.GetComponent<TopDownMovement>().enabled = false;
            cat.GetComponent<Level2MeowDialogue>().enabled = false;
         
        }
    }
}
