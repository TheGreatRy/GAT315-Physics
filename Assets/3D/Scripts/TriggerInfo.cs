using UnityEngine;

public class TriggerInfo : MonoBehaviour
{
    Material material;
    Color color;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = Color.green;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = Color.red;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = color;
        }
    }
}
