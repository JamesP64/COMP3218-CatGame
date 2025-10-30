using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject exit;
    public GameObject cat;
    public GameObject gameLogic;
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
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
        }
     
        Debug.Log(collision);
    }
}
