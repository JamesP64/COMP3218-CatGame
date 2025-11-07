using UnityEngine;

public class GameController : MonoBehaviour
{
    /*public GameObject PlateRotator;
    public GameObject PlateLightBox;*/

    public Statue TopStatue;
    public Statue RightStatue;
    public Statue LeftStatue;

    public GameObject cat;

    public void rotatorPlatePressed()
    {
        Debug.Log(this.name + "Rotate Pressed");
        TopStatue.rotate();
        RightStatue.rotate();
        LeftStatue.rotate();
    }
}
