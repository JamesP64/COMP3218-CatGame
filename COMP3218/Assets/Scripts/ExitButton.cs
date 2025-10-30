using UnityEngine;
using UnityEngine.UI;


public class ExitButton : MonoBehaviour
{
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(CloseGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseGame()
    {
        Application.Quit();
    }
}
