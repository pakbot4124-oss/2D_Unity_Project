using UnityEngine;

public class PlayerTouchSpotState : PlayerBaseState
{
    readonly int WallLedgeAnimationHash = Animator.StringToHash("WallLedge");

    public PlayerTouchSpotState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(WallLedgeAnimationHash, stateMachine.CrossFadeDuration);

    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        stateMachine.ForceReceive.MoveYVelocity(fixedDeltaTime, stateMachine.InputReader.MovementDirection * stateMachine.MoveSpeed);
        if (!stateMachine.SpotCheckSensor.isTouchSpot)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Tick(float deltaTime)
    {
    }

    public override void Exit()
    {
    }
}
