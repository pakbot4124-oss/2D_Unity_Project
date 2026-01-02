using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    readonly int DeathAnimationHash = Animator.StringToHash("Death");
    readonly string DeathAnimationTag = "Death";
    public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(DeathAnimationHash, stateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, DeathAnimationTag);
        if (normalizedTime > 0.8f && normalizedTime <= 1f)
        {
            Debug.Log("Game Over!");
        }
    }

    public override void Exit()
    {
    }
}
