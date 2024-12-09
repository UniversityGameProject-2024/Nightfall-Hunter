using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Tooltip("Speed of the bullet")]
    [SerializeField] private float speed = 10f;

    [Tooltip("Time before the bullet is destroyed")]
    [SerializeField] private float lifetime = 2f;

    private void Start()
    {
        // Destroy the bullet after a certain amount of time
        Destroy(gameObject, lifetime);
    }

    //private void Update()
    //{
    //    // Move the bullet in the direction it is facing (transform.up corresponds to the "forward" direction)
    //    transform.Translate(Vector2.up * speed * Time.deltaTime);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Handle bullet collisions (e.g., hit an enemy)
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Destroy the enemy
            Destroy(gameObject);        // Destroy the bullet
        }
    }
}
