using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera follows (player)
    public float smoothing = 5f; // The speed with which the camera will follow
    public Vector3 offset; // Offset between the camera and the target

    void Start()
    {
        // Calculate and store the offset value by getting the distance between the target's position and camera's position.
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Create a position the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and its target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
