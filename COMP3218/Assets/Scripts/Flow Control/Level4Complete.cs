using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Complete : MonoBehaviour
{
    public GameObject cat;
    public GameObject leftLookingDiag;
    public GameObject rightLookingDiag;  
    public GameObject topLookingDown;
    public string winScene;
    public GameObject gameLogic;
    private GameLogic logic;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip deniedSound;
    [SerializeField] private float audioVolume = 1.0f;
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        logic = gameLogic.GetComponent<GameLogic>();

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        StarsCollected.Instance.stars = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (leftLookingDiag.activeSelf && !rightLookingDiag.activeSelf && topLookingDown.activeSelf)
            {
                Debug.Log("Won");
                Debug.Log("star count: " + logic.getStarCount());
                StarsCollected.Instance.stars = logic.getStarCount();
                StarsCollected.Instance.max(4, logic.getStarCount());
                SceneManager.LoadScene(winScene, LoadSceneMode.Single);
            }
            else
            {
                if (deniedSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(deniedSound, audioVolume);
                }
            }
        }
    }
}
