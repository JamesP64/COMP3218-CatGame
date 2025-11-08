using UnityEngine;

public class StarDetect : MonoBehaviour
{
    public GameObject starLight;
    public GameObject starCollection;
    public GameObject gameLogic;
    private GameLogic logic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = gameLogic.GetComponent<GameLogic>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            starCollection.SetActive(true);
            starLight.SetActive(false);
            gameObject.SetActive(false);
            logic.increaseStarCount();
        }
    }
}
