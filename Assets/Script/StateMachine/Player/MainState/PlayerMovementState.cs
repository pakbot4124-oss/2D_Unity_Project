using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    readonly int MovementBlendTreeHash = Animator.StringToHash("MovementBlendTree");
    readonly int MovementSpeedParameter = Animator.StringToHash("MovementSpeed");
    public PlayerMovementState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.GroundCheckSensor.JumpCount = 0;
        stateMachine.Animator.CrossFadeInFixedTime(MovementBlendTreeHash, stateMachine.CrossFadeDuration);
        stateMachine.InputReader.JumpEvent += stateMachine.OnJump;
        stateMachine.InputReader.RollEvent += stateMachine.OnRoll;
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        ChangeAttackState();
        SetAnimation(fixedDeltaTime);
        Rotation();
        stateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, stateMachine.InputReader.MovementDirection * stateMachine.MoveSpeed);
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= stateMachine.OnJump;
        stateMachine.InputReader.RollEvent -= stateMachine.OnRoll;
    }

    void SetAnimation(float deltaTime)
    {
        if (stateMachine.InputReader.MovementDirection == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(MovementSpeedParameter, 0f, stateMachine.AnimationDamping, deltaTime);
            float current = stateMachine.Animator.GetFloat(MovementSpeedParameter);
            if (Mathf.Abs(current) < 0.001f)
            {
                stateMachine.Animator.SetFloat(MovementSpeedParameter, 0f, stateMachine.AnimationDamping, deltaTime);
            }
        }
        else
        {
            stateMachine.Animator.SetFloat(MovementSpeedParameter, 1f, stateMachine.AnimationDamping, deltaTime);
        }
    }

    void ChangeAttackState()
    {
        if (stateMachine.InputReader.IsAttack)
        {
            stateMachine.SwitchState(new PlayerAttackState(stateMachine, 0, stateMachine.Attacks));
            return;
        }
    }
}
