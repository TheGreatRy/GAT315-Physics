using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] float jumpHeight = 2;
    [SerializeField] LayerMask layerMask = Physics.AllLayers;

    Rigidbody rb;
    Vector3 force;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        direction.z = Input.GetAxis("Horizontal");
        direction.x = Input.GetAxis("Vertical");

        force = direction * speed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(-2.0f * Physics.gravity.y * jumpHeight), ForceMode.Impulse);
        }
        var colliders = Physics.OverlapSphere(transform.position, 2, layerMask);

        foreach (var collider in colliders)
        {
            Destroy(collider.gameObject);
        }

        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 5))
        {
            Destroy(hit.collider.gameObject);
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(force, ForceMode.Force);
        //rb.AddTorque(Vector3.up);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);
    }

}
