
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed;


    void Update()
    {
        float x = -Input.GetAxisRaw("Vertical");

        if (x > 0 && transform.position.x <= 2.0f)
        {
            transform.position += new Vector3(speed * x * Time.deltaTime, 0, 0);
        }
        else if (x < 0 && transform.position.x >= -6.196f)
        {
            transform.position += new Vector3(speed * x * Time.deltaTime, 0, 0);
        }
    }
}
