using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSpawner : MonoBehaviour
{
    //first spawn is always the starting position. We have no idea why this happens.
    void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(13.5f, 87.5f), 2.5f, Random.Range(20.0f, 80.0f));
        transform.position = randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 randomPos = new Vector3(Random.Range(13.5f, 87.5f), 2.5f, Random.Range(20.0f, 80.0f));
        transform.position = randomPos;
    }
}
