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

    private void Start()
    {
        logic = gameLogic.GetComponent<GameLogic>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && logic.getWin()==true)
        {
            Debug.Log("Won");
            SceneManager.LoadScene(winScene, LoadSceneMode.Single);
        } else
        {
            Debug.Log(collision.tag);
            Debug.Log(logic.getWin());
        }
        Debug.Log(collision);
    }
}
