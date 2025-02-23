using UnityEngine;

public class BallManager : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 lastCheckpoint;

    void Start()
    {
        startPosition = transform.position;
        lastCheckpoint = transform.position;
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
            RespawnBallStart(); 
            ResetPlatformRotation();
            ShowWinScreen();
        }
        else if (other.CompareTag("Checkpoint"))
        {
            lastCheckpoint = other.transform.position;
        }
    }

    void RespawnBall()
    {
        transform.position = lastCheckpoint;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void RespawnBallStart()
    {
        transform.position = startPosition;
        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void Update()
    {
        if (transform.position.y < -5) 
        {
            RespawnBall();
            ResetPlatformRotation();
        }
    }

    void ResetPlatformRotation()
    {
        GameObject platform = GameObject.Find("Platform");
        if (platform != null)
        {
            platform.transform.rotation = Quaternion.identity;
        }
    }

    void ShowWinScreen()
    {
        TimerManager timerManager = FindObjectOfType<TimerManager>();
        UIManager uiManager = FindObjectOfType<UIManager>();

        if (timerManager != null && uiManager != null)
        {
            timerManager.StopTimer();
            uiManager.ShowWinScreen(timerManager.GetTime());
        }
    }

}
