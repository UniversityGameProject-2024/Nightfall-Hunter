using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [Tooltip("Speed of the enemy's movement")]
    [SerializeField] private float speed = 3f;

    private Transform chaseTarget;

    private void Update()
    {
        if (chaseTarget != null)
        {
            // Move toward the chase target
            Vector3 direction = (chaseTarget.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotate to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void SetChaseTarget(Transform target)
    {
        chaseTarget = target;
    }

    public void StopChasing()
    {
        chaseTarget = null;
    }
}
