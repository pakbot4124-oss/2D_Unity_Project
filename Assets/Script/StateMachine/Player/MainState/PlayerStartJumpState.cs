using UnityEngine;

public class PlayerStartJumpState : PlayerBaseState
{
    readonly int StartJumpAnimationHash = Animator.StringToHash("StartJump");
    public PlayerStartJumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(StartJumpAnimationHash, stateMachine.CrossFadeDuration);
        stateMachine.ForceReceive.AddJumpForce(stateMachine.JumpForce);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        stateMachine.ForceReceive.MoveVelocity(GetDirByInput() * stateMachine.MoveSpeed, fixedDeltaTime);
        if (!stateMachine.GroundCheckSensor.isGrounded)
        {
            stateMachine.SwitchState(new PlayerInAirState(stateMachine));
            return;
        }
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
