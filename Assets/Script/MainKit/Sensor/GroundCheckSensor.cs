using UnityEngine;

public class GroundCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform groundCheckOffset;

    RaycastSensor groundCheck;
    public bool isGrounded;

    public int JumpCount { get; set; } = 0;


    void Start()
    {
        groundCheck = new RaycastSensor(this.transform);
        groundCheck.SetCastDirection(RaycastSensor.CastDirection.Down);
        groundCheck.castLength = castLength;
        groundCheck.layerMask = layerMask;
        groundCheck.SetOffset(groundCheckOffset.position);

    }

    void FixedUpdate()
    {
        groundCheck.Cast();
        isGrounded = groundCheck.HasDetected();
        // if (isGrounded)
        // {
        //     Debug.Log("cham dat");
        // }
    }
}
