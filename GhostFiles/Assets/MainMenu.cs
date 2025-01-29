using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameSceneName = "Level 1"; // Name of the scene for a new game

    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName); // Load the game scene
    }

    public void LoadGame()
    {
        Debug.Log("Load Game: Feature not implemented yet!");
        // Later, you can implement loading game progress here
    }

    public void Settings()
    {
        Debug.Log("Settings: Feature not implemented yet!");
        // Placeholder for settings menu functionality
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Quit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
#endif
    }
}
