using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TutorialChecklist : MonoBehaviour
{
    [Header("Checklist Toggles")]
    public Toggle moveTask;
    public Toggle meowTask;
   // public Toggle exitTask;

    public bool moveCompleted = false;
    public bool meowCompleted = false;

    private bool wPressed = false;
    private bool aPressed = false;
    private bool sPressed = false;
    private bool dPressed = false;
    public GameObject moveTaskLabel;
    public GameObject meowTaskLabel;
    public GameObject exitTaskLabel;
    public Color completedColour;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveCompleted && (Keyboard.current.wKey.wasPressedThisFrame ||
                               Keyboard.current.aKey.wasPressedThisFrame ||
                               Keyboard.current.sKey.wasPressedThisFrame ||
                               Keyboard.current.dKey.wasPressedThisFrame ))
        {
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                wPressed = true;
            }
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                aPressed = true;
            }
            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                sPressed = true;
            }
            if (Keyboard.current.dKey.wasPressedThisFrame)
            {
                dPressed = true;
            }
        }

        if(!moveCompleted && wPressed && aPressed && dPressed && sPressed) {
            moveCompleted = true;
            // change transparency of label
            moveTaskLabel.GetComponent<Text>().color = completedColour;
            meowTaskLabel.SetActive(true);
            moveTask.isOn = true;
        }

        if (moveCompleted && !meowCompleted && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            meowCompleted = true;
            // change transparency of label
            meowTaskLabel.GetComponent <Text>().color = completedColour;
            exitTaskLabel.SetActive(true);
            meowTask.isOn = true;
        }

    }
}
