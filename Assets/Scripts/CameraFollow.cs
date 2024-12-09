using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The player transform to follow")]
    [SerializeField] private Transform player;

    [Tooltip("The offset between the camera and the player")]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    [Tooltip("How smoothly the camera follows the player")]
    [SerializeField] private float followSpeed = 5f;

    [Tooltip("The minimum and maximum boundaries for the camera")]
    [SerializeField] private Vector2 minBounds;
    [SerializeField] private Vector2 maxBounds;

    private float cameraHalfWidth;
    private float cameraHalfHeight;

    private void Start()
    {
        // Calculate the camera's half-size based on the orthographic size and aspect ratio
        Camera mainCamera = Camera.main;
        cameraHalfHeight = mainCamera.orthographicSize;
        cameraHalfWidth = cameraHalfHeight * mainCamera.aspect;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position of the camera
            Vector3 targetPosition = player.position + offset;

            // Clamp the camera's position so it doesn't go outside the map boundaries
            float clampedX = Mathf.Clamp(targetPosition.x, minBounds.x + cameraHalfWidth, maxBounds.x - cameraHalfWidth);
            float clampedY = Mathf.Clamp(targetPosition.y, minBounds.y + cameraHalfHeight, maxBounds.y - cameraHalfHeight);

            // Smoothly interpolate the camera's position to the clamped target position
            Vector3 clampedPosition = new Vector3(clampedX, clampedY, targetPosition.z);
            transform.position = Vector3.Lerp(transform.position, clampedPosition, followSpeed * Time.deltaTime);
        }
    }
}
