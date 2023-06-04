using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PowerUpType
{
    Slow,
    Fast,
    x2,
    Pause,
    Bigger,
    Smaller,
    x2Boost,
    None
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Ball ball;

    [HideInInspector]
    public int player1Score;

    [HideInInspector]
    public int player2Score;

    public int maxscore;
    public bool isGameOver;
    public bool started = false;


    public PowerUpType PowerUpPlayer1;
    public PowerUpType PowerUpPlayer2;
    void Awake()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Score1()
    {
        player1Score++;
        UIManager.Instance.Score1Update();
        if(player1Score == maxscore)
        {
            GameOver1();
        }
    }
    public void Score2()
    {
        player2Score++;
        UIManager.Instance.Score2Update();
        if (player2Score == maxscore)
        {
            GameOver2();
        }
    }

    public void Powerup1(PowerUpType PowerUp)
    {
        PowerUpPlayer1 = PowerUp;
        UIManager.Instance.PoweUpUpdate1(PowerUp);
    }

    public void Powerup2(PowerUpType PowerUp) 
    {
        PowerUpPlayer2 = PowerUp;
        UIManager.Instance.PoweUpUpdate2(PowerUp);
    }
    public void GameOver1()
    {
        isGameOver = true;
        UIManager.Instance.Winner1();
        StartCoroutine(ResetSceneCoroutine());
    }
    public void GameOver2()
    {
        isGameOver = true;
        UIManager.Instance.Winner2();
        StartCoroutine(ResetSceneCoroutine());
    }
    private IEnumerator ResetSceneCoroutine()
    {
        yield return new WaitForSeconds(5f);
        UIManager.Instance.Reset();

        Ball ball = FindObjectOfType<Ball>();

        // Destroy all power-ups
        SpawnRoutine spawner = FindObjectOfType<SpawnRoutine>();
        if (spawner != null)
        {
            spawner.DestroyAllPowerUps();
        }

        // Reset power-ups
        PowerUpPlayer1 = PowerUpType.None;
        PowerUpPlayer2 = PowerUpType.None;
        UIManager.Instance.PoweUpUpdate1(PowerUpType.None);
        UIManager.Instance.PoweUpUpdate2(PowerUpType.None);

        // Reset scores
        player1Score = 0;
        player2Score = 0;
        UIManager.Instance.Score1Update();
        UIManager.Instance.Score2Update();

        isGameOver = false;

        if (ball != null)
        {
            ball.Reset();
        }

        // Reset the spawner
        if (spawner != null)
        {
            spawner.SpawnPURoutine();
        }
        UIManager.Instance.ToStart();
    }

    public PowerUpType GetCurrentPowerup(int playerid)
    {
        return (playerid == 1 ? PowerUpPlayer1 : PowerUpPlayer2);
    }

    public void usePowerup(PowerUpType power, int activatedBy) //actibated by: 1 / 2
    {
        if (power == PowerUpType.Slow) {
            StartCoroutine(slowBall());
        }
        //añadir restantes aqui
    }

    private IEnumerator slowBall()
    {
        ball.updateSpeed = false;
        ball.movementSpeed = ball.movementSpeed / 3;
        yield return new WaitForSeconds(5); //5 segundos de slow, cambiar si necesario
        ball.updateSpeed = true;
    }

}
