using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Tooltip("Reference to the enemy prefab")]
    [SerializeField] private GameObject _enemyPrefab;

    [Tooltip("Spawn points for enemies")]
    [SerializeField] private Transform[] _spawnPoints;

    [Tooltip("Time between enemy spawns (in seconds)")]
    [SerializeField] private float _spawnInterval = 3f;

    private float _spawnTimer;

    private void Update()
    {
        // Countdown the timer
        _spawnTimer -= Time.deltaTime;

        // If the timer reaches zero, spawn an enemy
        if (_spawnTimer <= 0f)
        {
            SpawnEnemy();
            _spawnTimer = _spawnInterval; // Reset the timer
        }
    }

    private void SpawnEnemy()
    {
        // Choose a random spawn point
        Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

        // Instantiate the enemy at the chosen spawn point
        GameObject enemy = Instantiate(_enemyPrefab, spawnPoint.position, Quaternion.identity);

        // Make sure the enemy has the necessary components
        PlayerAwarenessControl awarenessControl = enemy.GetComponent<PlayerAwarenessControl>();
        if (awarenessControl != null)
        {
            awarenessControl.enabled = true; // Ensure awareness control is active after spawning
        }

        // Optionally, you can explicitly set up other components, such as enemyMover:
        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();
        if (enemyMover != null)
        {
            enemyMover.SetChaseTarget(GameObject.FindGameObjectWithTag("Player").transform); // Set the player as the chase target
        }
    }
}
