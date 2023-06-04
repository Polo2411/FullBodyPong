using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    private bool relocate;


    private TrailRenderer myTrail;
    private Vector3 startLocation;
    [HideInInspector] public float movementSpeed;
    [HideInInspector] public bool updateSpeed; //disable when using speed related powerups
    private float startTime;
    private int touched;
    private Vector3 direction;
    public Space space;
    // Start is called before the first frame update
    void Start()
    {
        myTrail = GetComponent<TrailRenderer>();
        startLocation = transform.position;
        startTime = Time.realtimeSinceStartup;
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        direction.Normalize();
        touched = 0;
        movementSpeed = 0;
        updateSpeed = true;
    }

    public void Reset() //call when point has been scored
    {
        transform.position = startLocation;
        startTime = Time.realtimeSinceStartup;
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        direction.Normalize();
        myTrail.Clear();
        myTrail.enabled = true;
        touched = 0;
        movementSpeed = 0;
        updateSpeed = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.started)
        {
            // Check if Player 1 is within the specified range
            bool player1InRange = player1.transform.position.x >= 30 && player1.transform.position.x <= 70 &&
                                  player1.transform.position.z >= 5 && player1.transform.position.z <= 15;

            // Check if Player 2 is within the specified range
            bool player2InRange = player2.transform.position.x >= 30 && player2.transform.position.x <= 70 &&
                                  player2.transform.position.z >= 85 && player2.transform.position.z <= 95;

            if (player1InRange && player2InRange)
            {
                GameManager.Instance.started = true; // Enable ball movement
            }
        }

        if (GameManager.Instance.started)
        {
            UIManager.Instance.StartGame();
            if (updateSpeed) { movementSpeed = calculateMovementSpeed(); }
            transform.Translate(direction * movementSpeed * Time.deltaTime, space);
        }
    }

    private float calculateMovementSpeed()
    {
        float runtime = Time.realtimeSinceStartup - startTime;
        movementSpeed = 10 + runtime;
        return movementSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLISION: " + other.tag);
        if (other.CompareTag("PARED")) {
            direction.x = -direction.x;
            SoundManager.Instance.PlayHitSound();
        }
        if (other.CompareTag("Player1"))
        {
            Vector3 newDir = this.transform.position - player1.transform.position;
            if (this.transform.position.z < player1.transform.position.z) { newDir.z = -newDir.z; }
            newDir.y = 0;
            newDir = Vector3.Normalize(newDir);
            touched = 1;
            direction = newDir;
            SoundManager.Instance.PlayHitSound();
        }
        if (other.CompareTag("Player2"))
        {
            Vector3 newDir = this.transform.position - player2.transform.position;
            if (this.transform.position.z > player2.transform.position.z) { newDir.z = -newDir.z; }
            newDir.y = 0;
            newDir = Vector3.Normalize(newDir);
            touched = 2;
            direction = newDir;
            SoundManager.Instance.PlayHitSound();
        }
        if (other.CompareTag("BORDE1"))
        {
            GameManager.Instance.Score2();
            myTrail.enabled = false;
            SoundManager.Instance.PlayScoreSound();
            if (!GameManager.Instance.isGameOver)
            {
                Reset();
            }
        }
        if (other.CompareTag("BORDE2"))
        {
            GameManager.Instance.Score1();
            myTrail.enabled = false;
            SoundManager.Instance.PlayScoreSound();
            if (!GameManager.Instance.isGameOver)
            {
                Reset();
            }
        }
        //check powerup collision 
        //Check what player touched the ball before
        if (other.CompareTag("biggerselfPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.Bigger);
            }
            else if(touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.Bigger);
            }
            
        }
        else if (other.CompareTag("pauseballPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.Pause);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.Pause);
            }
        }
        else if (other.CompareTag("slowerballPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.Slow);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.Slow);
            }
        }
        else if (other.CompareTag("smallerenemyPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.Smaller);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.Smaller);
            }
        }
        else if (other.CompareTag("fasterballPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.Fast);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.Fast);
            }
        }
        else if (other.CompareTag("x2PU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.x2);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.x2);
            }
        }
        else if (other.CompareTag("x2BoostPU"))
        {
            SoundManager.Instance.PlayTakePowerSound();
            if (touched == 1)
            {
                GameManager.Instance.Powerup1(PowerUpType.x2Boost);
            }
            else if (touched == 2)
            {
                GameManager.Instance.Powerup2(PowerUpType.x2Boost);
            }
        }
    }
}

