using UnityEngine;

public class GameController : MonoBehaviour
{
    /*public GameObject PlateRotator;
    public GameObject PlateLightBox;*/

    public GameObject TopStatue;
    public GameObject RightStatue;
    public GameObject LeftStatue;

    public GameObject cat;

    public void rotatorPlatePressed()
    {
        TopStatue.rotate();
        RightStatue.rotate();
        LeftStatue.rotate();
    }
}
