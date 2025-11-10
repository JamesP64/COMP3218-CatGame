using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScript : MonoBehaviour
{
    public Button button2;
    public Button button3;
    public Button button4;
    public GameObject button2Label;
    public GameObject button3Label;
    public GameObject button4Label;
    public Color unlockedTextColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (StarsCollected.Instance.level2)
        {
            button2.interactable = true;
            button2Label.GetComponent<Text>().color = unlockedTextColor;
        }
        if (StarsCollected.Instance.level3)
        {
            button3.interactable = true;
            button3Label.GetComponent<Text>().color = unlockedTextColor;
        }
        if (StarsCollected.Instance.level4)
        {
            button4.interactable = true;
            button4Label.GetComponent<Text>().color = unlockedTextColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
