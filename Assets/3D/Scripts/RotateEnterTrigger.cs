using Unity.VisualScripting;
using UnityEngine;

public class RotateEnterTrigger : MonoBehaviour
{
    [SerializeField] GameObject rotateObject;
    [SerializeField] float rotationAngle;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rotateObject.transform.Rotate(Vector3.up, rotationAngle);

        }
    }

}
