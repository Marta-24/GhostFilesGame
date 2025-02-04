using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthManager healthManager; // Reference to the shared health manager

    public void TakeDamage(int damage)
    {
        if (healthManager != null)
        {
            healthManager.TakeDamage(damage); // Pass damage to the health manager
        }
    }
}
