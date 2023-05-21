using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int playerIndex;
    private float position;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIndex == 1)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, 10);
            setPosition(newPos);
        }

        if (playerIndex == 2)
        {
            Vector3 newPos = new Vector3(transform.position.x, 0, 90);
            setPosition(newPos);
        }

        position = transform.position.x;
        if (position > 90)
        {
            Vector3 newPos = new Vector3(90, transform.position.y, transform.position.z);
            setPosition(newPos);
        }

        if (position < 10)
        {
            Vector3 newPos = new Vector3(10, transform.position.y, transform.position.z);
            setPosition(newPos);
        }
    }

    public void setPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}