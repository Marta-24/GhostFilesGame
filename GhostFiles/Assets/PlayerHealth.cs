using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Total lives
    public int healthPerLife = 2; // How many health points per life (e.g., full = 2, half = 1)
    private int currentHealth;

    public Image[] heartImages; // Array of heart UI images
    public Sprite fullHeartSprite; // Sprite for a full heart
    public Sprite halfHeartSprite; // Sprite for a half heart
    public Sprite emptyHeartSprite; // Sprite for an empty heart

    void Start()
    {
        currentHealth = maxLives * healthPerLife; // Calculate total health
        UpdateHeartUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // Optional: Trigger Game Over here
            Debug.Log("Player has died!");
        }

        UpdateHeartUI();
    }

    void UpdateHeartUI()
    {
        // Update each heart based on current health
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
