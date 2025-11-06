using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public GameObject pauseMenu;
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
    }

}
