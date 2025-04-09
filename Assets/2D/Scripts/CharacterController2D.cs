using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    Rigidbody2D rb;
    Vector2 force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.zero;
        direction.x = Input.GetAxis("Horizontal");

        force = direction * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(-2.0f * Physics.gravity.y * jumpHeight), ForceMode2D.Impulse);
        }
        animator.SetFloat("Speed", Mathf.Abs(direction.x));
        if (direction.x > 0.05f) spriteRenderer.flipX = false;
        else if (direction.x < -0.05f) spriteRenderer.flipX = true;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(force.x, rb.linearVelocity.y);
        //rb.AddForce(force, ForceMode2D.Force);
    }

}

