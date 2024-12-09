using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Tooltip("The player transform to follow")]
    [SerializeField] private Transform player;

    [Tooltip("The offset between the camera and the player")]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);

    [Tooltip("How smoothly the camera follows the player")]
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position of the camera
            Vector3 targetPosition = player.position + offset;

            // Smoothly interpolate the camera's position to the target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
