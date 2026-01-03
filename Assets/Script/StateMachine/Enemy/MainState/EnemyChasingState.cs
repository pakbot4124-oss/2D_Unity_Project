using UnityEngine;

public class EnemyChasingState : EnemyBaseState
{
    readonly int WalkAnimationHash = Animator.StringToHash("Walk");
    public EnemyChasingState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(WalkAnimationHash, enemyStateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        Chasing(enemyStateMachine.Player.transform, fixedDeltaTime);
        RotationToTarget();
    }

    public override void Tick(float deltaTime)
    {
        if (IsAttackZone())
        {
            enemyStateMachine.SwitchState(new EnemyAttackState(enemyStateMachine, 0, enemyStateMachine.Attacks));
        }

        if (!IsChasingZone())
        {
            enemyStateMachine.ReturnLocomotion();
        }
    }

    public override void Exit()
    {
    }
}
