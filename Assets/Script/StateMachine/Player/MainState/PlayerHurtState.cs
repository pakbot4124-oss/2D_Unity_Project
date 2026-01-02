using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{
    readonly int HurtAnimationHash = Animator.StringToHash("Hurt");
    readonly string HurtAnimationTag = "Hurt";
    public PlayerHurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(HurtAnimationHash, stateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, HurtAnimationTag);
        if (normalizedTime > 0.8f && normalizedTime <= 1f)
        {
            stateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
    }
}
