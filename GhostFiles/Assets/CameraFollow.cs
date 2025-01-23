using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.05f; // Faster smoothing for platformers
    public Vector3 offset; // Maintain a slight offset

    void LateUpdate()
    {
        if (target != null)
        {
            // Directly follow the target, with less smoothing
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    }

    public void UpdateTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
