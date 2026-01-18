using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpotCheckSensor))]
[RequireComponent(typeof(WallCheckSensor))]
[RequireComponent(typeof(GroundCheckSensor))]
public class ForceReceive : MonoBehaviour
{
    [Header("Gravity")]
    [SerializeField] float gravity = -30f;
    [SerializeField] float maxDownForce = -50;

    [Header("Collision")]

    GroundCheckSensor groundCheckSensor;
    SpotCheckSensor spotCheckSensor;
    WallCheckSensor wallCheckSensor;

    Rigidbody2D rb2D;
    float verticalVelocity;

    ContactFilter2D contactFilter2D = new ContactFilter2D();
    RaycastHit2D[] hits = new RaycastHit2D[5];
    public Vector2 Movement => Vector2.up * verticalVelocity;


    void Start()
    {

        if (gameObject.CompareTag("Player"))
        {
            groundCheckSensor = GetComponent<GroundCheckSensor>();
            wallCheckSensor = GetComponent<WallCheckSensor>();
            spotCheckSensor = GetComponent<SpotCheckSensor>();
            spotCheckSensor = GetComponent<SpotCheckSensor>();
        }
        rb2D = GetComponent<Rigidbody2D>();
        contactFilter2D.useTriggers = true;
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Ground"));

    }

    void FixedUpdate()
    {
        ApplyGravity(Time.fixedDeltaTime);
    }

    void ApplyGravity(float fixedDeltaTime)
    {
      if(verticalVelocity <= 0f && groundCheckSensor.isGrounded)
        {
            verticalVelocity = 0f;
        }
        else
        {
            verticalVelocity += gravity * fixedDeltaTime;
        }
    }


    public void MoveVelocity(Vector2 motion, float fixedDeltaTime)
    {
        Vector2 totalMovement = (motion + Movement) * fixedDeltaTime;

        int hitCount = rb2D.Cast(
            totalMovement.normalized,
            contactFilter2D,
            hits,
            totalMovement.magnitude
            );

        if (hitCount > 0)
        {
            float distance = hits[0].distance - 0.1f;
            totalMovement = totalMovement.normalized * distance;
            
            if(Vector2.Dot(Vector2.up, hits[0].normal) > 0.5f)
            {
                verticalVelocity = 0f;
            }
        }

        rb2D.MovePosition(rb2D.position + totalMovement);
    }

    public void AddJumpForce(float jumpForce)
    {
        verticalVelocity = jumpForce;
    }
}
