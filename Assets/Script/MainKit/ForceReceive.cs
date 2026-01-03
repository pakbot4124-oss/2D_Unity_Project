using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ForceReceive : MonoBehaviour
{
    [SerializeField] float downForce = 2f;

    GroundCheckSensor groundCheckSensor;
    Rigidbody2D rb2D;

    void Start()
    {
        if (gameObject.tag == "Player")
        {
            groundCheckSensor = GetComponent<GroundCheckSensor>();
        }

        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (gameObject.tag == "Player")
        {
            if (rb2D.linearVelocityY <= 0 && groundCheckSensor.isGrounded)
            {
                rb2D.linearVelocityY = 0;
            }
            else
            {
                rb2D.linearVelocityY += Physics2D.gravity.y * downForce * Time.fixedDeltaTime;
            }
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
