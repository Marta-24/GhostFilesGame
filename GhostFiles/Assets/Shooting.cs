using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign a circle prefab here
    public Transform shootPoint; // The point from where the projectile is fired

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
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
    }
}
