using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    readonly int WalkAnimationHash = Animator.StringToHash("Walk");
    float time;
    public EnemyPatrolState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(WalkAnimationHash, enemyStateMachine.CrossFadeDuration);
        RotationToPatrol();
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        enemyStateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, GetXDirection() * enemyStateMachine.MoveSpeed);
    }

    public override void Tick(float deltaTime)
    {
        time += deltaTime;
        if (time >= enemyStateMachine.TimeToPatrol)
        {
            enemyStateMachine.ReturnLocomotion();
        }

        if (IsChasingZone())
        {
            enemyStateMachine.SwitchState(new EnemyChasingState(enemyStateMachine));
        }
    }

    public override void Exit()
    {
    }
}
