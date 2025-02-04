using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Hide the pause menu
        Time.timeScale = 1f; // Resume game time
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Show the pause menu
        Time.timeScale = 0f; // Pause game time
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Ensure time is unpaused before restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene
    }

    public void Quit()
    {
        Time.timeScale = 1f; // Ensure time is unpaused before quitting
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Ensure time is unpaused before changing scenes
        SceneManager.LoadScene("MainMenu"); // Replace with your Main Menu scene name
    }
}
