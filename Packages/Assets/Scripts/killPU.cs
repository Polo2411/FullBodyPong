using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPU : MonoBehaviour
{
    SpawnRoutine PUspawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BALL"))
        {

            Destroy(gameObject);
        }
    }
    public void SetSpawner(SpawnRoutine spawner)
    {
        PUspawner = spawner;
    }

}
