using UnityEngine;
using UnityEngine.UI;

public class ContinueButton3 : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject cat;
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(Continue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // makes the canvas not active
    void Continue()
    {
        pauseMenu.SetActive(false);
        cat.GetComponent<TopDownMovement>().enabled = true;
        cat.GetComponent<Level3MeowDialogue>().enabled = true;
    }

}
