using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake Instance; // Singleton reference

    private Vector3 shakeOffset; // Offset added by screen shake
    private float shakeDuration = 0f;
    private float shakeIntensity = 0f;

    private Transform cameraTransform;
    private Vector3 originalPosition; // The position provided by the camera follow script

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
        cameraTransform = transform; // Reference the camera's transform
    }

    void LateUpdate()
    {
        if (shakeDuration > 0)
        {
            // Generate random offset for the shake
            shakeOffset = (Vector3)Random.insideUnitCircle * shakeIntensity;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeOffset = Vector3.zero; // Reset shake offset when finished
        }

        // Combine the follow position (provided by another script) with the shake offset
        cameraTransform.position = originalPosition + shakeOffset;
    }

    // Call this method from the camera follow script to set the follow position
    public void SetOriginalPosition(Vector3 position)
    {
        originalPosition = position;
    }

    // Trigger a screen shake
    public void Shake(float duration, float intensity)
    {
        shakeDuration = duration;
        shakeIntensity = intensity;
    }
}
