using UnityEngine;

public class PlayerAwarenessControl : MonoBehaviour
{
    [Tooltip("Reference to the player GameObject")]
    [SerializeField] private Transform player;

    [Tooltip("Detection range of the enemy")]
    [SerializeField] private float detectionRadius = 5f;

    [Tooltip("Reference to the EnemyMover script")]
    [SerializeField] private EnemyMover enemyMover;

    private void Awake()
    {
        // Ensure that the player and enemyMover are assigned correctly.
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform; // Automatically find player by tag
        }

        if (enemyMover == null)
        {
            enemyMover = GetComponent<EnemyMover>(); // Get the EnemyMover if not manually set
        }
    }

    private void Update()
    {
        if (player == null || enemyMover == null) return;

        // Calculate distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Enable or disable chasing based on distance
        if (distanceToPlayer <= detectionRadius)
        {
            enemyMover.SetChaseTarget(player);
        }
        else
        {
            enemyMover.StopChasing();
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the detection radius in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
