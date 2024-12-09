using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("The starting health of the player")]
    [SerializeField] private int maxHealth = 3;

    [Tooltip("TextMeshPro UI element to display health")]
    [SerializeField] private TextMeshProUGUI healthText;

    private int currentHealth;
    private bool isDead = false;

    private void Start()
    {
        // Initialize the player's health
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        UpdateHealthUI();

        // Check if the player has died
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player has died!");

        // Handle death (e.g., restart game, show game over screen)
        GameOver();
    }

    private void GameOver()
    {
        // Example: Restart the level
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    private void UpdateHealthUI()
    {
        // Update the TextMeshPro text to display current health
        if (healthText != null)
        {
            healthText.text = $"Health: {currentHealth}";
        }
    }
}
