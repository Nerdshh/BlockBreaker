using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] Paddle paddleOne;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    // States
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddleOne.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }  
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddleOne.transform.position.x, paddleOne.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
}
