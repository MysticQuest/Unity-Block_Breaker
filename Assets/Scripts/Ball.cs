using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 paddleBallAnchor;

    [SerializeField] float xPush;
    [SerializeField] float yPush;

    [SerializeField] bool hasStarted = false;

    [SerializeField] AudioClip[] ballSounds;
    AudioSource myAudioSource;

    Rigidbody2D ballBody;
    [SerializeField] float randomFactor = 0.5f;

    // Use this for initialization
    void Start()
    {
        paddleBallAnchor = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        ballBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            ballBody.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleBallAnchor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(-0.5f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            ballBody.velocity += velocityTweak;
        }
    }
}
