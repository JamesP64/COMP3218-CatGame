using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScript : MonoBehaviour
{
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public GameObject button2Label;
    public GameObject button3Label;
    public GameObject button4Label;
    public GameObject button5Label;
    public Text level2Stars;
    public Text level3Stars;
    public Text level4Stars;
    public Text level5Stars;
    public Color unlockedTextColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (StarsCollected.Instance.level2)
        {
            button2.interactable = true;
            button2Label.GetComponent<Text>().color = unlockedTextColor;
            level2Stars.color = unlockedTextColor;
            level2Stars.text = "stars: " + StarsCollected.Instance.maxLevel2.ToString();
        }
        if (StarsCollected.Instance.level3)
        {
            button3.interactable = true;
            button3Label.GetComponent<Text>().color = unlockedTextColor;
            level3Stars.color = unlockedTextColor;
            level3Stars.text = "stars: " + StarsCollected.Instance.maxLevel3.ToString();
        }
        if (StarsCollected.Instance.level4)
        {
            button4.interactable = true;
            button4Label.GetComponent<Text>().color = unlockedTextColor;
            level4Stars.color = unlockedTextColor;
            level4Stars.text = "stars: " + StarsCollected.Instance.maxLevel4.ToString();
        }
        if (StarsCollected.Instance.level5)
        {
            button5.interactable = true;
            button5Label.GetComponent<Text>().color = unlockedTextColor;
            level5Stars.color = unlockedTextColor;
            level5Stars.text = "stars: " + StarsCollected.Instance.maxLevel5.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
