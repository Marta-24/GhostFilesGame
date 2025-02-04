using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxLives = 3; // Total lives
    public int healthPerLife = 2; // Health points per life (full = 2, half = 1)
    private int currentHealth;

    public Image[] heartImages; // Array of heart UI images
    public Sprite fullHeartSprite; // Sprite for a full heart
    public Sprite halfHeartSprite; // Sprite for a half heart
    public Sprite emptyHeartSprite; // Sprite for an empty heart

    public GameObject deathScreenPanel; // Reference to the death screen panel

    void Start()
    {
        currentHealth = maxLives * healthPerLife; // Initialize total health
        UpdateHeartUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHeartUI();
    }

    void Die()
    {
        Debug.Log("Player has died!");
        Time.timeScale = 0f; // Pause the game
        deathScreenPanel.SetActive(true); // Show the death screen
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; // Unpause the game
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f; // Unpause the game
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            int heartHealth = Mathf.Clamp(currentHealth - (i * healthPerLife), 0, healthPerLife);
            if (heartHealth == 2)
            {
                heartImages[i].sprite = fullHeartSprite;
            }
            else if (heartHealth == 1)
            {
                heartImages[i].sprite = halfHeartSprite;
            }
            else
            {
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }
}
