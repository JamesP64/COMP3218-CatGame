using UnityEngine;

public class WinStarManager : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star1Outline;
    public GameObject star2Outline;
    public GameObject star3Outline;
    private int starCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        starCount = StarsCollected.Instance.stars;
        Debug.Log("star count: " + starCount);
        if (starCount == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        if (starCount == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            star1Outline.SetActive(false);
            star2Outline.SetActive(false);
            star3Outline.SetActive(true);
        }
        if (starCount == 1)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            star1Outline.SetActive(false);
            star2Outline.SetActive(true);
            star3Outline.SetActive(true);
        }
        if (starCount == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            star1Outline.SetActive(true);
            star2Outline.SetActive(true);
            star3Outline.SetActive(true);
        }
    }
}
