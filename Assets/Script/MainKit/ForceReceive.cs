using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// [RequireComponent(typeof(GroundCheckSensor))]
public class ForceReceive : MonoBehaviour
{
    [SerializeField] float downForce = 2f;
    GroundCheckSensor groundCheckSensor;
    SpotCheckSensor spotCheckSensor;
    WallCheckSensor wallCheckSensor;

    Rigidbody2D rb2D;

    void Start()
    {
        if (gameObject.CompareTag("Player"))
        {
            groundCheckSensor = GetComponent<GroundCheckSensor>();
            spotCheckSensor = GetComponent<SpotCheckSensor>();
        }

        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (spotCheckSensor.isTouchSpot)
            {
                rb2D.linearVelocityX = 0;
                return;
            }


            if (rb2D.linearVelocityY <= 0.0001f && groundCheckSensor.isGrounded)
            {
                rb2D.linearVelocityY = 0f;
            }
            else
            {
                rb2D.linearVelocityY += Physics2D.gravity.y * downForce * Time.fixedDeltaTime;
            }

            if (wallCheckSensor)
            {
                rb2D.linearVelocityX = 0;

            }
        }
        // Debug.Log(rb2D.linearVelocityY);
    }

    public void MoveVelocity(float fixedDeltaTime, Vector2 motion)
    {
        rb2D.linearVelocityX = motion.x * fixedDeltaTime;
    }

    public void MoveYVelocity(float fixedDeltaTime, Vector2 motion)
    {
        rb2D.linearVelocityY = motion.y * fixedDeltaTime;
    }

    public void Jump(float jumpForce)
    {
        rb2D.linearVelocityY = jumpForce;
    }
}
