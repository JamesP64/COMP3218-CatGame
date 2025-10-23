using UnityEngine;
using UnityEngine.InputSystem;

public class MeowDialogue : MonoBehaviour
{

    public GameObject speechBubble;
    public float displayDuration = 2.0f;

    private GameObject activeBubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowSpeechBubble();
        }

    }

    void ShowSpeechBubble()
    {
        if(activeBubble != null)
        {
            Destroy(activeBubble);
        }
        activeBubble = Instantiate(speechBubble, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        activeBubble.transform.SetParent(transform);
        Destroy(activeBubble, displayDuration);
    }
}
