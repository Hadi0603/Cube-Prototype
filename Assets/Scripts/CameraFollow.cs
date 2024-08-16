using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 5.0f;
    public float verticalClampAngle = 30.0f; // Limits for looking up and down

    private float currentYaw = 0f;
    private float currentPitch = 0f;

    void LateUpdate()
    {
        // Get mouse input for rotating the camera
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Update yaw (horizontal rotation) based on Mouse X input
        currentYaw += mouseX;

        // Update pitch (vertical rotation) based on Mouse Y input and clamp it
        currentPitch -= mouseY;
        currentPitch = Mathf.Clamp(currentPitch, -verticalClampAngle, verticalClampAngle);

        // Apply the rotation to the camera
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(player.position);
    }
}
