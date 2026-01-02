using UnityEngine;

public class PlayerInAirState : PlayerBaseState
{
    readonly int InAirAnimationHash = Animator.StringToHash("Fall");

    public PlayerInAirState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(InAirAnimationHash, stateMachine.CrossFadeDuration);
        stateMachine.InputReader.JumpEvent += stateMachine.OnJump;

    }

    public override void PhysicsTick(float fixedDeltaTime)
    {


        Rotation();
        stateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, stateMachine.InputReader.MovementDirection * stateMachine.MoveSpeed / 1.5f);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Rigidbody2D.linearVelocityY <= 0 && stateMachine.GroundCheckSensor.isGrounded)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= stateMachine.OnJump;
    }
}
