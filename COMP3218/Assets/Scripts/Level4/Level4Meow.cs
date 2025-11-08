using UnityEngine;
using UnityEngine.InputSystem;

public class Level4Meow : MonoBehaviour
{
    private GameObject activeBubble;
    private AudioSource audioData;
    private GameLogic logic;
    public GameObject speechBubble;
    public float displayDuration = 2f;
    public float activationRadius = 2f;
    public LayerMask statueLayer;
    public GameObject gameLogic;

    public GameController gameController;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        logic = gameLogic.GetComponent<GameLogic>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            ShowSpeechBubble();
            audioData.Play(0);
            ActivateNearbyLights();
        }
    }

    void ShowSpeechBubble()
    {
        if (activeBubble != null) Destroy(activeBubble);
        activeBubble = Instantiate(speechBubble, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
        activeBubble.transform.SetParent(transform);
        Destroy(activeBubble, displayDuration);
    }

    void ActivateNearbyLights()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, activationRadius, statueLayer);
        foreach (Collider2D collider in colliders)
        {
            Statue statue = collider.GetComponentInParent<Statue>();
            if (statue != null)
            {
                statue.activate();
            }

        }
    }
}
