using UnityEngine;

public class Fire : MonoBehaviour
{
    public int fireHealth = 3; // Number of hits the fire can take
    public int damage = 1; // Damage dealt to the player
    private float damageCooldown = 1f; // Cooldown in seconds
    private float lastDamageTime = -1f; // Time of the last damage

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the fire is hit by a bullet
        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject); // Destroy the bullet
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        fireHealth--; // Reduce fire health by 1

        if (fireHealth <= 0)
        {
            ExtinguishFire();
        }
    }

    void ExtinguishFire()
    {
        // Add effects like particles or sounds here if desired
        Destroy(gameObject); // Destroy the fire object
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null && Time.time > lastDamageTime + damageCooldown)
            {
                lastDamageTime = Time.time; // Update the last damage time
                playerHealth.TakeDamage(damage);

                // Trigger screen shake
                ScreenShake.Instance.Shake(0.3f, 0.2f); // Duration: 0.3s, Intensity: 0.2
            }
        }
    }
}
