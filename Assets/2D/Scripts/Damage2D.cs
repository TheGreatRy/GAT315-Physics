using UnityEngine;

/// <summary>
/// Applies damage to objects with Health components during collisions or triggers.
/// Controls damage amount, frequency, and filtering by tags and layers.
/// </summary>
public class Damage2D : MonoBehaviour
{
	[SerializeField] float damageAmount = 10;
	[SerializeField] float damageRate = 1;
	[SerializeField] bool destroySelfOnDamage = false;

	[SerializeField] string affectTag;
	[SerializeField] LayerMask affectLayers = Physics.AllLayers;

	// Timestamp when next damage can be applied
	float damageTimer = 0;

	/// <summary>
	/// Called when this collider begins touching another collider
	/// </summary>
	private void OnCollisionEnter2D(Collision2D collision)
	{
		ApplyDamage(collision.gameObject);
	}

	/// <summary>
	/// Called every fixed update while this collider is touching another collider
	/// </summary>
	private void OnCollisionStay2D(Collision2D collision)
	{
		ApplyDamage(collision.gameObject);
	}

	/// <summary>
	/// Called when another collider enters this trigger
	/// </summary>
	private void OnTriggerEnter2D(Collider2D collision)
	{
		ApplyDamage(collision.gameObject);
	}

	/// <summary>
	/// Called every fixed update while another collider stays in this trigger
	/// </summary>
	private void OnTriggerStay2D(Collider2D collision)
	{
		ApplyDamage(collision.gameObject);
	}

	/// <summary>
	/// Attempts to apply damage to a target if cooldown has elapsed and target is valid
	/// </summary>
	/// <param name="target">The GameObject to potentially damage</param>
	private void ApplyDamage(GameObject target)
	{
		// Skip if cooldown hasn't elapsed or target doesn't meet criteria
		if (Time.time < damageTimer || !IsValid(target)) return;

		// Try to get and damage the Health component
		if (target.TryGetComponent(out Health health))
		{
			health.ApplyDamage(damageAmount);
			damageTimer = Time.time + damageRate;

			// Optionally destroy this object after dealing damage
			if (destroySelfOnDamage)
			{
				Destroy(gameObject);
			}
		}
	}

	/// <summary>
	/// Checks if the target object meets the layer and tag criteria for damage
	/// </summary>
	/// <param name="gameObject">The GameObject to validate</param>
	/// <returns>True if the GameObject can be damaged, false otherwise</returns>
	private bool IsValid(GameObject gameObject)
	{
		// Check if the object's layer is in our affect layers mask
		if ((affectLayers & (1 << gameObject.layer)) == 0)
		{
			return false;
		}

		// If no tag specified, or if object has matching tag, it's valid
		return (string.IsNullOrEmpty(affectTag) || gameObject.CompareTag(affectTag));
	}
}