using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;  // The object that the camera will follow
    public Vector3 offset;   // The offset from the target object
    public float smoothSpeed = 0.125f;  // The speed at which the camera will follow the target object

    void LateUpdate()
    {
        // Calculate the position that the camera should be at based on the target object's position and the offset
        Vector3 desiredPosition = target.position + offset;

        // Use smooth damp to move the camera towards the desired position over time
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the position of the camera
        transform.position = smoothedPosition;

        // Make sure the camera is always looking at the target object
        transform.LookAt(target);
    }
}