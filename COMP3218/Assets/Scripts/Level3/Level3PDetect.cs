using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3PDetect : MonoBehaviour
{

    public GameObject boxPos1;
    public GameObject boxPos2;

    public GameObject boxPos1Light;
    public GameObject boxPos2Light;

    public GameObject boxPos1SafeZoneNotOccluded;
    public GameObject boxPos2SafeZoneNotOccluded;
    public GameObject boxPos1SafeZoneOccluded;
    public GameObject boxPos2SafeZoneOccluded;

    public GameObject TopEyes;
    public GameObject LeftEyes;

    public GameObject boxPos1Border;
    public GameObject boxPos2Border;

    public Level3MeowDialogue dialogue;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (boxPos1.activeSelf)
            {
                // Swap Box Sprites
                boxPos1.SetActive(!boxPos1.activeSelf);
                boxPos2.SetActive(!boxPos2.activeSelf);
                // Swap Box Colliders
                boxPos1Border.SetActive(!boxPos1Border.activeSelf);
                boxPos2Border.SetActive(!boxPos2Border.activeSelf);
                //Turn off Box's light
                boxPos1Light.SetActive(false);
                boxPos1SafeZoneOccluded.SetActive(false);
                //If top eyes are on, turn on safe zone now box is out of the way
                if(TopEyes.activeSelf)
                {
                    boxPos1SafeZoneNotOccluded.SetActive(true);
                }
                //If left eyes are on, turn its light on, and turn off the unoccluded safe zone
                if(LeftEyes.activeSelf) 
                {
                    boxPos2Light.SetActive(true);
                    boxPos2SafeZoneOccluded.SetActive(true);
                    boxPos2SafeZoneNotOccluded.SetActive(false);
                }
            }else
            {
                boxPos1.SetActive(!boxPos1.activeSelf);
                boxPos2.SetActive(!boxPos2.activeSelf);
                boxPos1Border.SetActive(!boxPos1Border.activeSelf);
                boxPos2Border.SetActive(!boxPos2Border.activeSelf);
                boxPos2Light.SetActive(false);
                boxPos2SafeZoneOccluded.SetActive(false);
                if (LeftEyes.activeSelf)
                {
                    boxPos2SafeZoneNotOccluded.SetActive(true);
                }
                if (TopEyes.activeSelf)
                {
                    boxPos1Light.SetActive(true);
                    boxPos1SafeZoneOccluded.SetActive(true);
                    boxPos1SafeZoneNotOccluded.SetActive(false);
                }
            }
        }
    }
}
