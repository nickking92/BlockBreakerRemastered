using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {



    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15;
    [SerializeField] float ScreenwidthInUnits = 16f;
    GameStatus gs;
    Ball ball;

    // Update is called once per frame

    private void Start()
    {
        gs = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }
    void Update() {
       // float mousePos = Input.mousePosition.x / Screen.width * ScreenwidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPosition(), minX, maxX);
        transform.position = paddlePos;


    }
    private float GetXPosition()
    {
        if (gs.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {

            return Input.mousePosition.x / Screen.width * ScreenwidthInUnits;

        }
    }
}
