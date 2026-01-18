using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    readonly int IdleAnimationHash = Animator.StringToHash("Idle");
    float time;
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(IdleAnimationHash, enemyStateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        //enemyStateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, Vector2.zero);
    }

    public override void Tick(float deltaTime)
    {
        time += deltaTime;
        if (IsChasingZone())
        {
            enemyStateMachine.SwitchState(new EnemyChasingState(enemyStateMachine));
            return;
        }

        if (time >= enemyStateMachine.TimeToIdle)
        {
            enemyStateMachine.SwitchState(new EnemyPatrolState(enemyStateMachine));
        }
    }

    public override void Exit()
    {
    }
}
