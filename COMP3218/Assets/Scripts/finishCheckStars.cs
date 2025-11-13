using Unity.VisualScripting;
using UnityEngine;

public class finishCheckStars : MonoBehaviour
{
    public GameObject text;
    public GameObject collectedAllText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Total stars: " + StarsCollected.Instance.getTotalStars());
        if (StarsCollected.Instance.totalStars == 11)
        {
            text.SetActive(false);
        }else
        {
            collectedAllText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

