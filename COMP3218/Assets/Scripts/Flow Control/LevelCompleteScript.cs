using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject exit;
    public GameObject cat;
    public GameObject gameLogic;
    public string winScene;
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
        if (collision.CompareTag("Player") && logic.getWin()==true)
        {
            Debug.Log("Won");
            Debug.Log("star count: " + logic.getStarCount());
            StarsCollected.Instance.stars = logic.getStarCount();

            Debug.Log(SceneManager.GetActiveScene().name);
            if (SceneManager.GetActiveScene().name.Equals("Level1"))
            {
                StarsCollected.Instance.level2 = true;
                StarsCollected.Instance.max(1, logic.getStarCount());
            }
            if (SceneManager.GetActiveScene().name.Equals("Level2"))
            {
                StarsCollected.Instance.level3 = true;
                StarsCollected.Instance.max(2, logic.getStarCount());
            }
            if (SceneManager.GetActiveScene().name.Equals("Level3"))
            {
                StarsCollected.Instance.level4 = true;
                StarsCollected.Instance.max(3, logic.getStarCount());
            }
            StarsCollected.Instance.updateTotalStars();
            SceneManager.LoadScene(winScene, LoadSceneMode.Single);
        } else
        { 
            if(deniedSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(deniedSound, audioVolume);
            }
            Debug.Log(collision.tag);
            Debug.Log(logic.getWin());
        }
        Debug.Log(collision);
    }
}
