using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    
    void Start()
    { }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space ) )
        {
            Instantiate( toSpawn, transform.position, transform.rotation);
        }
    }
}
