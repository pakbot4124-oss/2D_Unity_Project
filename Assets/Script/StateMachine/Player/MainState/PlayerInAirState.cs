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
        stateMachine.ForceReceive.MoveVelocity(GetDirByInput() * stateMachine.MoveSpeed, fixedDeltaTime);
        if (stateMachine.GroundCheckSensor.isGrounded)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.GroundCheckSensor.isGrounded)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= stateMachine.OnJump;
    }
}
