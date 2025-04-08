using UnityEngine;

public class PointEffector : MonoBehaviour
{
    [SerializeField] float minRadius = 2;
    [SerializeField] float maxRadius = 10;
    [SerializeField] float force = 10;
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 forceVector = Vector3.zero;
        Vector3 direction = other.transform.position - transform.position;
        float distance = direction.magnitude;

        if (rb != null)
        {
            float t = Mathf.InverseLerp(minRadius, maxRadius, distance);
            forceVector = direction.normalized * force * (1 - t);
            rb.AddForce(forceVector);
        }
    }
}
