using UnityEngine;

public class CollisionInfo : MonoBehaviour
{
    Material material;
    Color color;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            material.color = Color.green;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            material.color = Color.red;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            material.color = color;
        }
    }

}
