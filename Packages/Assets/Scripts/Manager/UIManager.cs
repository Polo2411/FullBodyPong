using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Text score1;
    public Text score2;
    public Text End1;
    public Text End2;
    public GameObject gameOverWindow1;
    public GameObject gameOverWindow2;
    public GameObject start1;
    public GameObject start2;
    public Image Powerup1;
    public Image Powerup2;
    public Sprite Slow;
    public Sprite Fast;
    public Sprite x2;
    public Sprite Pause;
    public Sprite Bigger;
    public Sprite Smaller;
    public Sprite x2Boost;
    public Sprite None;

    void Awake()
    {
        Instance = this;

    }

    public void Score1Update()
    {
        score1.text = GameManager.Instance.player1Score.ToString();
    }
    public void Score2Update()
    {
        score2.text = GameManager.Instance.player2Score.ToString();
    }
    public void PoweUpUpdate1(PowerUpType power)
    {
        if(power == PowerUpType.Slow)
        {
            Powerup1.sprite = Slow;
        }
        if (power == PowerUpType.Fast)
        {
            Powerup1.sprite = Fast;
        }
        if (power == PowerUpType.Bigger)
        {
            Powerup1.sprite = Bigger;
        }
        if (power == PowerUpType.Smaller)
        {
            Powerup1.sprite = Smaller;
        }
        if (power == PowerUpType.x2)
        {
            Powerup1.sprite = x2;
        }
        if (power == PowerUpType.Pause)
        {
            Powerup1.sprite = Pause;
        }
        if (power == PowerUpType.x2Boost)
        {
            Powerup1.sprite = x2Boost;
        }
        if (power == PowerUpType.None)
        {
            Powerup1.sprite = None;
        }
    }
    public void PoweUpUpdate2(PowerUpType power)
    {
        if (power == PowerUpType.Slow)
        {
            Powerup2.sprite = Slow;
        }
        if (power == PowerUpType.Fast)
        {
            Powerup2.sprite = Fast;
        }
        if (power == PowerUpType.Bigger)
        {
            Powerup2.sprite = Bigger;
        }
        if (power == PowerUpType.Smaller)
        {
            Powerup2.sprite = Smaller;
        }
        if (power == PowerUpType.x2)
        {
            Powerup2.sprite = x2;
        }
        if (power == PowerUpType.Pause)
        {
            Powerup2.sprite = Pause;
        }
        if (power == PowerUpType.x2Boost)
        {
            Powerup2.sprite = x2Boost;
        }
        if (power == PowerUpType.None)
        {
            Powerup2.sprite = None;
        }
    }
    public void Winner1()
    {
        End1.text = "WINNER";
        End2.text = "LOSER";
        SoundManager.Instance.PlayEndSound();
        gameOverWindow1.SetActive(true);
        gameOverWindow2.SetActive(true);
    }
    public void Winner2()
    {
        End1.text = "LOSER";
        End2.text = "WINNER";
        SoundManager.Instance.PlayEndSound();
        gameOverWindow1.SetActive(true);
        gameOverWindow2.SetActive(true);
    }
    public void Reset()
    {
        gameOverWindow1.SetActive(false);
        gameOverWindow2.SetActive(false);
    }
    public void StartGame()
    {
        start1.SetActive(false);
        start2.SetActive(false);
    }
    public void ToStart()
    {
        start1.SetActive(true);
        start2.SetActive(true);
    }
}
