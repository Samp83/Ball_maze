using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winScreen;
    public Text winText;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void ShowWinScreen(float time)
    {
        winScreen.SetActive(true);
        DisableControls();
    }

    void DisableControls()
    {

        PlatformController platformController = FindObjectOfType<PlatformController>();
        if (platformController != null)
        {
            platformController.enabled = false;
        }

        BallManager ballManager = FindObjectOfType<BallManager>();
        if (ballManager != null)
        {
            ballManager.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
