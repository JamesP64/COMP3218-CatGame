using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    public enum TutorialStep
    {
        Movement,
        Meow,
        Completed
    }

    private TutorialStep currentStep = TutorialStep.Movement;
    private bool movementKeysPressed = false;
    private bool meowKeyPressed = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tutorialText.text = "Use W A S D to move";

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentStep)
        {
            case TutorialStep.Movement:
                CheckMovementInput();
                break;
            case TutorialStep.Meow:
                CheckMeowInput();
                break;

        }
    }

    void CheckMovementInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.aKey.wasPressedThisFrame ||
            Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.dKey.wasPressedThisFrame)
        {
            movementKeysPressed = true;
            currentStep = TutorialStep.Meow;
            tutorialText.text = "Press Space to meow";
        }

    }

    void CheckMeowInput()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            meowKeyPressed = true;
            currentStep = TutorialStep.Completed;
            tutorialText.text = "Walk towards the entrance to go to the next level";
        }
    }
}