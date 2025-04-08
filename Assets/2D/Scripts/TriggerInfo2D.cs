using UnityEngine;

public class TriggerInfo2D : MonoBehaviour
{
    Material material;
    Color color;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        color = material.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = Color.green;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = Color.red;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            material.color = color;
        }
    }
}
