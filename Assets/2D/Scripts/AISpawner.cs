using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
    [SerializeField] float timer = 5;

    float storeTimer;
    void Start()
    {
        storeTimer = timer;
    }


    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(toSpawn, transform.position, transform.rotation);
            timer = storeTimer;
        }
    }
}
