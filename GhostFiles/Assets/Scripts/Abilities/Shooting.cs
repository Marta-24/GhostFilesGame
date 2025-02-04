using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign a circle prefab here
    public Transform shootPoint; // The point from where the projectile is fired
    public int maxAmmo = 10; // Maximum ammo
    private int currentAmmo; // Current ammo count
    public TMP_Text ammoText; // UI text to display ammo

    void Start()
    {
        currentAmmo = maxAmmo; // Start with full ammo
        UpdateAmmoUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0)
        {
            // Get the mouse position in world space
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate the direction to shoot
            Vector3 shootDirection = (mousePosition - shootPoint.position).normalized;

            // Instantiate the projectile
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

            // Rotate the projectile to face the direction of the mouse
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(0, 0, angle);

            // Reduce ammo count
            currentAmmo--;
            UpdateAmmoUI();
        }
        else
        {
            Debug.Log("Out of ammo! Find a refill."); // Later, we add UI feedback
        }
    }

    void UpdateAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo + "/" + maxAmmo;
        }
    }

    public void RefillAmmo()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoUI();
    }
}
