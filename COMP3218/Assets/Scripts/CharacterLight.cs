using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLight : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        pos.z = 0;

        var angle = Vector3.Angle(pos - transform.position, Vector3.down);

        if (pos.x > transform.position.x)
            angle *= -1;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180 - angle), 300 * Time.deltaTime);
    }
}
