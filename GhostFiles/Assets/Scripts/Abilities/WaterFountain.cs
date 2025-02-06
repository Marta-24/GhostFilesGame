using UnityEngine;
using TMPro; // For TextMeshPro UI
using System.Collections; // Needed for Coroutine

public class WaterFountain : MonoBehaviour
{
    public int refillAmount = 10; // Max ammo refill
    public GameObject refillPromptUI; // UI that shows "Press E to Refill"
    public TMP_Text refillText; // The UI text component
    private bool isPlayerNearby = false; // Track if player is near
    private bool isReloading = false; // Track if already refilling

    void Start()
    {
        if (refillPromptUI != null)
        {
            refillPromptUI.SetActive(false); // Hide the UI at start
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isReloading)
        {
            StartCoroutine(RefillAmmo()); // Start reload process
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (refillPromptUI != null)
            {
                refillPromptUI.SetActive(true); // Show UI when player enters
                refillText.text = "Press E to Refill"; // Default UI text
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (refillPromptUI != null)
            {
                refillPromptUI.SetActive(false); // Hide UI when player leaves
            }
        }
    }

    IEnumerator RefillAmmo()
    {
        isReloading = true; // Start reload process
        refillText.text = "Refilling..."; // Change UI text

        yield return new WaitForSeconds(2f); // Wait 2 seconds for refill

        Shooting shootingScript = FindObjectOfType<Shooting>(); // Find the Shooting script in the scene

        if (shootingScript != null)
        {
            shootingScript.RefillAmmo(); // Call the refill function in Shooting.cs
            Debug.Log("Ammo refilled!");
            refillText.text = "Press E to Refill"; // Reset text after reloading
        }
        else
        {
            Debug.LogWarning("No Shooting script found!");
        }

        isReloading = false; // Allow refilling again
    }
}
