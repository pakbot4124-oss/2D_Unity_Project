using UnityEngine;
[RequireComponent (typeof(BoxCollider2D))]
public class GroundCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform groundCheckOffset;
    [SerializeField] BoxCollider2D box;
    RaycastSensor groundCheck;

    public bool isGrounded; //{ get; private set; }
    public int JumpCount { get; set; } = 0;


    void Start()
    {
        groundCheck = new RaycastSensor(this.transform, box);
        groundCheck.SetCastDirection(RaycastSensor.CastDirection.Down);
        groundCheck.castLength = castLength;
        groundCheck.layerMask = layerMask;
        groundCheck.SetOffset(groundCheckOffset.position);
    }

    public LayerMask GetLayerMask() => layerMask;
    public float GetGroundDistance() => groundCheck.GetDisTance();

    void FixedUpdate()
    {
        groundCheck.Cast();
        isGrounded = groundCheck.HasDetected();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
    }
}
