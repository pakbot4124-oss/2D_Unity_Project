using UnityEngine;

public class EnemyHurtState : EnemyBaseState
{
    readonly int HurtAnimationHash = Animator.StringToHash("Hurt");
    readonly string HurtAnimationTag = "Hurt";
    public EnemyHurtState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(HurtAnimationHash, enemyStateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {

    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(enemyStateMachine.Animator, HurtAnimationTag);
        if (normalizedTime > .8f && normalizedTime < 1f)
        {
            enemyStateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
    }
}
