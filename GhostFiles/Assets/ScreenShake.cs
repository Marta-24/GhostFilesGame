using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance; // Singleton reference

    private Vector3 originalPosition;
    private float shakeDuration = 0f;
    private float shakeIntensity = 0f;

    void Awake()
    {
        // Ensure only one instance of ScreenShake exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        originalPosition = transform.position; // Store the initial camera position
    }

    void LateUpdate()
    {
        if (shakeDuration > 0)
        {
            // Apply random shake
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            // Reset to original position when shake ends
            transform.position = originalPosition;
        }
    }

    public void Shake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
