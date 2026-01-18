using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    readonly string AttackAnimationTag = "Attack";
    Attacks attack;
    int currentIndex;
    float previousFrameTime;

    public EnemyAttackState(EnemyStateMachine enemyStateMachine, int index, Attacks[] attackComboList) : base(enemyStateMachine)
    {
        currentIndex = index >= attackComboList.Length ? 0 : index;
        attack = attackComboList[currentIndex];
    }

    public override void Enter()
    {
        enemyStateMachine.Animator.CrossFadeInFixedTime(attack.AttackAnimationName, enemyStateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        RotationToTarget();
        //enemyStateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, GetXDirection() * enemyStateMachine.MoveSpeed / 12f);
    }

    public override void Tick(float deltaTime)
    {
        float normalized = GetNormalizedTime(enemyStateMachine.Animator, AttackAnimationTag);
        if (normalized >= previousFrameTime && normalized <= 1f)
        {
            if (IsAttackZone())
            {
                TryCombo(enemyStateMachine.Attacks, attack.AttackAnimationNextIndex, previousFrameTime);
            }
        }
        else
        {
            enemyStateMachine.ReturnLocomotion();
        }
        previousFrameTime = normalized;
    }

    public override void Exit()
    {
    }

    void TryCombo(Attacks[] attackComboList, int nextIndex, float normalizedTime)
    {
        if (attack.AttackAnimationNextIndex == -1) { return; }
        if (normalizedTime < attack.AttackAnimationTime) { return; }

        enemyStateMachine.SwitchState(new EnemyAttackState(
            enemyStateMachine,
            nextIndex,
            attackComboList
        ));
    }
}
