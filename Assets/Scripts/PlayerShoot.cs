using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [Tooltip("Reference to the bullet prefab")]
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _bulletSpeed;

    // Update is called once per frame
    private void Update()
    {
        // Check if the left mouse button is pressed
        if (Mouse.current.leftButton.isPressed)
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePosition.z = 0; // Ensure the z-coordinate is zero (for 2D)

        // Calculate the shooting direction
        Vector2 shootDirection = (mousePosition - transform.position).normalized;

        // Instantiate the bullet at the player's position
        GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet and set its velocity
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = _bulletSpeed * shootDirection;
    }
}
