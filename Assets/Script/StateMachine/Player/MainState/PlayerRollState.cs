
using UnityEngine;

public class PlayerRollState : PlayerBaseState
{
    readonly int RollAnimationHash = Animator.StringToHash("Roll");
    readonly string RollAnimationTag = "Roll";


    public PlayerRollState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(RollAnimationHash, stateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        stateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, stateMachine.InputReader.MovementDirection * stateMachine.MoveSpeed * 1.5f);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, RollAnimationTag);
        if (normalizedTime > 0.8f && normalizedTime <= 1f)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
    }
}
