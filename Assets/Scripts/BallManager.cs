using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            RespawnBall();
        }
        else if (other.CompareTag("Goal"))
        {
            Debug.Log("Victoire !");
            
        }
    }

    void RespawnBall()
    {
        transform.position = startPosition;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
