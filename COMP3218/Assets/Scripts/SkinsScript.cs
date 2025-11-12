using UnityEngine;
using UnityEngine.UI;

public class SkinsScript : MonoBehaviour
{
    public GameObject skin1;
    public GameObject skin2;
    public GameObject text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(StarsCollected.Instance.totalStars == 11)
        {
            skin1.gameObject.SetActive(true);
            skin2.gameObject.SetActive(true);
            text.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
