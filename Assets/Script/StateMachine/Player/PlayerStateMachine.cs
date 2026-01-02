using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [Header("Main parameter")]
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public BoxCollider2D BoxCollider2D { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public ForceReceive ForceReceive { get; private set; }
    [field: SerializeField] public GroundCheckSensor GroundCheckSensor { get; private set; }
    [field: SerializeField] public Attacks[] Attacks { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [Header("Animation parameter")]
    [field: SerializeField] public float CrossFadeDuration { get; private set; }
    [field: SerializeField] public float AnimationDamping { get; private set; }

    [Header("Movement parameter")]
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }


    void Start()
    {
        SwitchState(new PlayerMovementState(this));
    }

    void OnEnable()
    {
        Health.OnHurt += OnHurt;
        Health.OnDeath += OnDeath;
    }

    void OnDisable()
    {
        Health.OnHurt -= OnHurt;
        Health.OnDeath -= OnDeath;
    }

    public void ReturnLocomotion()
    {
        SwitchState(new PlayerMovementState(this));
        return;
    }

    public void OnHurt()
    {
        SwitchState(new PlayerHurtState(this));
        return;
    }

    public void OnDeath()
    {
        SwitchState(new PlayerDeathState(this));
        return;
    }

    public void OnRoll()
    {
        SwitchState(new PlayerRollState(this));
        return;
    }

    public void OnJump()
    {
        if (GroundCheckSensor.isGrounded || GroundCheckSensor.JumpCount < 2)
        {
            GroundCheckSensor.JumpCount++;
            SwitchState(new PlayerStartJumpState(this));
            return;
        }
    }
}
