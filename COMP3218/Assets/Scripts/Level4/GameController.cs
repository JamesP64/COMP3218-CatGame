using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /*public GameObject PlateRotator;
    public GameObject PlateLightBox;*/

    public Statue TopStatue;
    public static bool topFrozen;

    public Statue RightStatue;
    public static bool rightFrozen;

    public Statue LeftStatue;
    public static bool leftFrozen;  

    public GameObject cat;

    private float freezeDuration;

    private void Start()
    {
        topFrozen = false;
        rightFrozen = false;
        leftFrozen= false;
        freezeDuration = 20f;
    }


    public void rotatorPlatePressed()
    {
        Debug.Log(this.name + "Rotate Pressed");
        Debug.Log("TopFrozen: " + topFrozen);
        Debug.Log("RightFrozen: " + rightFrozen);
        Debug.Log("LeftFrozen: " + leftFrozen);
        if (!topFrozen){
            TopStatue.rotate();
        }if (!rightFrozen){
            RightStatue.rotate();
        }if (!leftFrozen) { 
            LeftStatue.rotate();    
        }
    }

    public void freeze(Statue statue)
    {
        if (statue == TopStatue)
        {
            topFrozen = true;
            StartCoroutine(Thaw(topFrozen));
            statue.freeze(freezeDuration);
        }
        if (statue == RightStatue)
        {
            rightFrozen = true;
            StartCoroutine(Thaw(rightFrozen));
            statue.freeze(freezeDuration);
        }
        if (statue == LeftStatue)
        {
            leftFrozen = true;
            StartCoroutine(Thaw(leftFrozen));
            statue.freeze(freezeDuration);
        }

    }
    IEnumerator Thaw(bool statueFreeze)
    {
        yield return new WaitForSeconds(freezeDuration);
        statueFreeze = false;
    }
}
