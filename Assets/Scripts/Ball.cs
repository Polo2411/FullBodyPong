using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private bool relocate;
    public int player1Score;
    public int player2Score;


    private TrailRenderer myTrail;
    //private SpawnRoutine PUspawner;
    private Vector3 startLocation;
    private float movementSpeed;
    private float startTime;
    private Vector3 direction;
    public Space space;
    // Start is called before the first frame update
    void Start()
    {
        myTrail = GetComponent<TrailRenderer>();
        startLocation = transform.position;
        startTime = Time.realtimeSinceStartup;
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Debug.Log("X:" + direction.x + "\tZ:" +direction.z +"\n");
        direction.Normalize();
        movementSpeed = 0;
    }

    private void Reset() //call when point has been scored
    {
        
        transform.position = startLocation;
        startTime = Time.realtimeSinceStartup;
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        direction.Normalize();
        myTrail.Clear();
        myTrail.enabled = true;
        movementSpeed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        movementSpeed = calculateMovementSpeed();
        transform.Translate(direction*movementSpeed*Time.deltaTime, space);
    }

    private float calculateMovementSpeed()
    {
        float runtime = startTime - Time.realtimeSinceStartup;
        movementSpeed = 10 + 10 * runtime;
        return movementSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION: " + other.tag);
        if (other.CompareTag("PARED")) {
            direction.x = -direction.x;
        }
        if (other.CompareTag("Player"))
        {
            direction.z = -direction.z; //REVISAR sistema de apuntado
        }
        if (other.CompareTag("BORDE1"))
        {
            player2Score++;
            myTrail.enabled = false;
            Reset();
        }
        if (other.CompareTag("BORDE2"))
        {
            player1Score++;
            myTrail.enabled = false;
            Reset();
        }
        //check powerup collision 
        /*
        if (other.CompareTag("biggerselfPU"))
        {

        }
        else if (other.CompareTag("pauseballPUPU"))
        {

        }
        else if (other.CompareTag("slowerballPU"))
        {

        }
        else if (other.CompareTag("smallerenemyPU"))
        {

        }
        else if (other.CompareTag("x2BoostPU"))
        {

        }
        else if (other.CompareTag("x2PU"))
        {

        } */
    }
}

