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
            moveCompleted = true;
            moveTask.isOn = true;
        }

        if (moveCompleted && !meowCompleted && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            meowCompleted = true;
            meowTask.isOn = true;
        }

    }
}
