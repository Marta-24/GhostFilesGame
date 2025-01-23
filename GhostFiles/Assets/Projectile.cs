using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        // Destroy the projectile after `lifeTime` seconds
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the projectile forward
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
