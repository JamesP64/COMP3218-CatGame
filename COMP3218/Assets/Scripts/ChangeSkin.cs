using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    public Button button;
    public bool onOff;

    void Start()
    {
        button.onClick.AddListener(ChangeCatSkin);
    }

    void ChangeCatSkin()
    {
        SkinSettings.IsRainbow = onOff; 
    }
}
