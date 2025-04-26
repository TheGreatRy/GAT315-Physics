using UnityEngine;
using UnityEngine.Events;

public class CollisionInteractor2D : Interactor
{
	[SerializeField] private string[] tagsToAffect; // Only damage objects with these tags
	[SerializeField] private LayerMask affectLayers = Physics.AllLayers; // Only damage objects on these layers

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (IsValid(collision.gameObject))
		{
			onInteractorStart.Invoke(collision.gameObject);
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if (IsValid(collision.gameObject))
		{
			onInteractorActive.Invoke(collision.gameObject);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (IsValid(collision.gameObject))
		{
			onInteractorEnd.Invoke(collision.gameObject);
		}
	}


	bool IsValid(GameObject target)
	{
		// Check if the other object is on a valid interaction layer
		// The bitwise operation creates a mask for the target's layer and compares it with our affectLayers mask
		if ((affectLayers & (1 << target.layer)) == 0)
		{
			return false; // Object's layer is not in our affect layers mask
		}

		// Check if we should damage this object based on tags
		if (tagsToAffect != null && tagsToAffect.Length > 0)
		{
			bool hasValidTag = false;
			// Loop through all tags that we can affect
			foreach (string tag in tagsToAffect)
			{
				if (target.CompareTag(tag))
				{
					hasValidTag = true;
					break;
				}
			}

			// Return false if the object doesn't have any of our valid tags
			if (!hasValidTag)
				return false;
		}

		return true;
	}
}
