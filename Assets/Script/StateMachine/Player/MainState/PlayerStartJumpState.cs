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
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {

        stateMachine.ForceReceive.Jump(stateMachine.JumpForce);
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Rigidbody2D.linearVelocityY > 0 && !stateMachine.GroundCheckSensor.isGrounded)
        {
            stateMachine.SwitchState(new PlayerInAirState(stateMachine));
        }
    }

    public override void Exit()
    {
    }
}
