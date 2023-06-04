using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager game_manager;
    [SerializeField] int playerIndex;
    private float position;
    private float currentY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentY <= 10)
        {
            usePowerup(playerIndex);
        }

    }

    public void setPosition(Vector3 pos)
    {
        if (playerIndex == 1)
        {
            Vector3 newPos = new Vector3(pos.x, 0, Mathf.Clamp(pos.z, 5, 20));
            transform.position = newPos;
        }
        else if (playerIndex == 2)
        {
            Vector3 newPos = new Vector3(pos.x, 0, Mathf.Clamp(pos.z, 95, 80));
            transform.position = newPos;
        }

        Vector3 alignment = new Vector3(Mathf.Clamp(transform.position.x, 10, 90), 0, transform.position.z);
        transform.position = alignment;
        currentY = pos.y;

    }

    public void usePowerup(int player)
    {
        //To be checked:
        //SoundManager.Instance.PlayUsePowerSound();
        if (player == 1)
        {
            PowerUpType power = PowerUpType.None;
            power = game_manager.GetCurrentPowerup(1);
            game_manager.usePowerup(power, 1);
            game_manager.PowerUpPlayer1 = PowerUpType.None;

        }
        else if (player == 2)
        {
            PowerUpType power = PowerUpType.None;
            power = game_manager.GetCurrentPowerup(2);
            game_manager.usePowerup(power, 2);
            game_manager.PowerUpPlayer2 = PowerUpType.None;
        }
    }
}
