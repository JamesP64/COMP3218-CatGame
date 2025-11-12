using Unity.VisualScripting;
using UnityEngine;

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
            skin1.SetActive(true);
            skin2.SetActive(true);
            text.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
