using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    public float rotationSpeed = 5.0f;

    private float currentYaw = 0f;

    void LateUpdate()
    {
        // Get mouse input for rotating the camera
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        currentYaw += mouseX;
        Quaternion rotation = Quaternion.Euler(0f, currentYaw, 0f);
        Vector3 desiredPosition = player.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }
}
