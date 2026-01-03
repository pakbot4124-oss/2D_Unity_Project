using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    readonly int DeathAnimationHash = Animator.StringToHash("Death");
    readonly string DeathAnimationTag = "Death";
    public EnemyDeathState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(DeathAnimationHash, enemyStateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(enemyStateMachine.Animator, DeathAnimationTag);
        if(normalizedTime > .8f && normalizedTime < 1f)
        {
            // enemyStateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
    }
}
