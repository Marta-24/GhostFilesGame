using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player or active character to follow
    public float smoothSpeed = 0.125f; // Smooth following speed
    public Vector3 offset; // Offset from the target

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the target position
            Vector3 desiredPosition = target.position + offset;

            // Smoothly interpolate to the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Pass the calculated position to the ScreenShake system
            ScreenShake.Instance.SetOriginalPosition(smoothedPosition);
        }
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
