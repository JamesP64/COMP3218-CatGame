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
    public AudioSource audioData;

    private void Start()
    {
        logic = gameLogic.GetComponent<GameLogic>();
        StarsCollected.Instance.stars = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (leftLookingDiag.activeSelf && !rightLookingDiag.activeSelf && topLookingDown.activeSelf)
            {
                Debug.Log(SceneManager.GetActiveScene().name);
                if (SceneManager.GetActiveScene().name.Equals("Level4"))
                {
                    Debug.Log("Won");
                    Debug.Log("star count: " + logic.getStarCount());
                    StarsCollected.Instance.stars = logic.getStarCount();
                    StarsCollected.Instance.max(4, logic.getStarCount());
                    StarsCollected.Instance.level4 = true;
                    SceneManager.LoadScene(winScene, LoadSceneMode.Single);
                }
                if (SceneManager.GetActiveScene().name.Equals("Level5"))
                {
                    Debug.Log("Won");
                    Debug.Log("star count: " + logic.getStarCount());
                    StarsCollected.Instance.stars = logic.getStarCount();
                    StarsCollected.Instance.max(5, logic.getStarCount());
                    StarsCollected.Instance.level5 = true;
                    SceneManager.LoadScene(winScene, LoadSceneMode.Single);
                }
            }else
            {
                Debug.Log("win condition not fulfilled");
                audioData.Play(0);
            }
        }
    }
}
