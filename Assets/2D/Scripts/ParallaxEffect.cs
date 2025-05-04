using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startingPosition;
    private float spriteLength;
    public float parallaxAmount;
    public Camera mainCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Getting the starting X position of sprite.
        startingPosition = transform.position.x;
        //Getting the length of the sprites.
        spriteLength = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 Position = mainCamera.transform.position;
        float Temp = Position.x * (1 - parallaxAmount);
        float Distance = Position.x * parallaxAmount;

        Vector3 NewPosition = new Vector3(startingPosition + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;
   

        if (Temp > startingPosition + (spriteLength / 2))
        {
            startingPosition += spriteLength;
        }
        else if (Temp < startingPosition - (spriteLength / 2))
        {
            startingPosition -= spriteLength;
        }
    
    }   
}
