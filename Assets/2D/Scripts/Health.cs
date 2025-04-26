using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the health state of a game object, handling damage, healing, and death.
/// </summary>
public class Health : MonoBehaviour
{
	[SerializeField] private float health = 100;              // Current health amount
	[SerializeField] private float maxHealth = 100;           // Maximum possible health
	[SerializeField] private bool destroyOnDeath = true;      // Whether to destroy the game object on death
	[SerializeField] private float destroyDelay = 0;          // Delay before destroying the game object (useful for death animations)
	[SerializeField] private UnityEvent onDamage;
	[SerializeField] private UnityEvent onDeath;

	private bool isDead = false;                              // Flag to track death state

	/// <summary>
	/// Initialize health to maxHealth when the component is created.
	/// </summary>
	private void Awake()
	{
		health = maxHealth;
	}

	/// <summary>
	/// Applies damage to this entity.
	/// </summary>
	/// <param name="damage">Amount of damage to apply</param>
	public void ApplyDamage(float damage)
	{
		// Don't apply damage if already dead or invulnerable
		if (isDead) return;

		onDamage?.Invoke();
		// Reduce health by damage amount
		health -= damage;

		// Check if health is depleted
		if (health <= 0)
		{
			Die();
		}
	}

	/// <summary>
	/// Heals this entity by the specified amount, up to the maximum health.
	/// </summary>
	/// <param name="amount">Amount of health to restore</param>
	public void Heal(float amount)
	{
		// Don't heal if already dead
		if (isDead) return;

		// Increase health, capped at maximum health
		health = Mathf.Min(health + amount, maxHealth);
	}

	/// <summary>
	/// Handles the death of this entity.
	/// </summary>
	public void Die()
	{
		// Prevent multiple death calls
		if (isDead) return;
		
		onDeath?.Invoke();
		// Set death state
		isDead = true;
		health = 0;

		// Destroy the game object if configured to do so
		if (destroyOnDeath)
		{
			Destroy(gameObject, destroyDelay);
		}
	}
}