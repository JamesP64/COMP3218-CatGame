using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Complete : MonoBehaviour
{
    public GameObject cat;
    public GameObject leftLookingDiag;
    public GameObject rightLookingDiag;  
    public GameObject topLookingDown;
    public string winScene;

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (leftLookingDiag.activeSelf && !rightLookingDiag.activeSelf && topLookingDown.activeSelf)
            {
                Debug.Log("Won");
                SceneManager.LoadScene(winScene, LoadSceneMode.Single);
            }
        }
    }
}
