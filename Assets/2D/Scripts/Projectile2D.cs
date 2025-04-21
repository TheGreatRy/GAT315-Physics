using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile2D : MonoBehaviour
{
	[SerializeField] float speed = 1;
	[SerializeField] ForceMode2D forceMode;
	[SerializeField] bool orientToVelocity = true;
	[SerializeField] float gravityScale = 1;

	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.gravityScale = gravityScale;

		rb.AddRelativeForce(transform.forward, forceMode);
	}

	private void Update()
	{
		if (orientToVelocity && rb.linearVelocity.magnitude != 0)
		{
			transform.forward = rb.linearVelocity;
		}
	}
}
