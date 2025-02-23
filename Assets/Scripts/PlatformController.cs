using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float rotationSpeed = 5f;

    void Update()
    {
        float rotateX = Input.GetAxis("Vertical") * rotationSpeed;
        float rotateZ = -Input.GetAxis("Horizontal") * rotationSpeed;

        transform.Rotate(rotateX * Time.deltaTime, 0, rotateZ * Time.deltaTime);
    }
}
