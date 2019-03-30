using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float wunits;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    GameSession gameSession;
    Ball theBall;

    // Use this for initialization
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * wunits);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
        //float mousePosInUnits = Input.mousePosition.x / Screen.width * wunits;

        PaddleMouseMovement();

    }

    private void PaddleMouseMovement()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (gameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }
    }
}
