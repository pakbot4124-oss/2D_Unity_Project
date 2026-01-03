using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [Header("Main parameter")]
    [field: SerializeField] public Rigidbody2D Rigidbody2D { get; private set; }
    [field: SerializeField] public BoxCollider2D BoxCollider2D { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceive ForceReceive { get; private set; }
    [field: SerializeField] public Attacks[] Attacks { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }

    [Header("Animation parameter")]
    [field: SerializeField] public float CrossFadeDuration { get; private set; }
    [field: SerializeField] public float AnimationDamping { get; private set; }

    [Header("Movement parameter")]
    [field: SerializeField] public float MoveSpeed { get; private set; }

    [Header("State parameter")]
    [field: SerializeField] public float ChasingRadius { get; private set; }
    [field: SerializeField] public float AttackRadius { get; private set; }
    [field: SerializeField] public float TimeToPatrol { get; private set; }
    [field: SerializeField] public float TimeToIdle { get; private set; }

    public Health Player {get; private set;}

    void Start()
    {
        ReturnLocomotion();
        Player = GameObject.FindWithTag("Player").GetComponent<Health>();
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
        SwitchState(new EnemyIdleState(this));
        return;
    }

    protected void OnHurt()
    {
        SwitchState(new EnemyHurtState(this));
        return;
    }

    protected void OnDeath()
    {
        SwitchState(new EnemyDeathState(this));
        return;
    }
}
