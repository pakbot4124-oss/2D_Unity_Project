using UnityEngine;

public class ForceReceive : MonoBehaviour
{
    [SerializeField] float downForce = 2f;

    GroundCheckSensor groundCheckSensor;
    Rigidbody2D rb2D;

    // float verticalVelocity;

    // Vector2 Movement => new Vector2(rb2D.linearVelocityX, rb2D.linearVelocityY);


    void Start()
    {
        groundCheckSensor = this.GetComponent<GroundCheckSensor>();
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb2D.linearVelocityY <= 0 && groundCheckSensor.isGrounded)
        {
            rb2D.linearVelocityY = 0;
        }
        else
        {
            rb2D.linearVelocityY += Physics2D.gravity.y * downForce * Time.fixedDeltaTime;
        }
        // Debug.Log(rb2D.linearVelocityY);
    }

    public void MoveVelocity(float fixedDeltaTime, Vector2 motion)
    {
        rb2D.linearVelocityX = motion.x * fixedDeltaTime;
    }

    public void Jump(float jumpForce)
    {
        rb2D.linearVelocityY = jumpForce;
    }
}
