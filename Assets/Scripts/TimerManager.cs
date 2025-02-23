using UnityEngine;
using TMPro; // IMPORTANT pour TextMeshPro

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; 

    private float timeElapsed;
    private bool isRunning = true;

    void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
            timerText.text = "Time: " + timeElapsed.ToString("F2") + "s";
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public float GetTime()
    {
        return timeElapsed;
    }
}
