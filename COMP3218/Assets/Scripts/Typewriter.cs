using UnityEngine;
using TMPro;
using System.Collections;

public class Typewriter : MonoBehaviour
{
    public TMP_Text textUI;
    public float delay = 0.05f;

    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        string fullText = textUI.text;
        textUI.text = "";

        audioSource.Play();

        foreach (char c in fullText)
        {
            textUI.text += c;
            yield return new WaitForSeconds(delay);
        }

        audioSource.Stop();
    }
}
