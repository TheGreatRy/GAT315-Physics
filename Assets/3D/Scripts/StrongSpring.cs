using UnityEngine;

public class StrongSpring : MonoBehaviour
{
    [SerializeField] float springForce = 500;
    SpringJoint springJoint;
    Vector3 startPosition;
    Quaternion startRotation;
    Rigidbody rb;
    void Start()
    {
        springJoint = GetComponent<SpringJoint>();
        rb = GetComponent<Rigidbody>();
        springJoint.spring = 1;
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            springJoint.spring = springForce;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            springJoint.spring = 0;
            rb.linearVelocity = Vector3.zero;   
            springJoint.gameObject.transform.position = startPosition;
            springJoint.gameObject.transform.rotation = startRotation;

        }
    }
}
