
public class PlayerAttackState : PlayerBaseState
{
    readonly string AttackAnimationTag = "Attack";
    float previousFrameTime;
    Attacks attack;
    int currentAttackIndex;


    public PlayerAttackState(PlayerStateMachine stateMachine, int index, Attacks[] attackComboList) : base(stateMachine)
    {
        currentAttackIndex = index;
        if (index >= attackComboList.Length)
        {
            currentAttackIndex = 0;
        }
        attack = attackComboList[currentAttackIndex];
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(attack.AttackAnimationName, stateMachine.CrossFadeDuration);
    }

    public override void PhysicsTick(float fixedDeltaTime)
    {
        Rotation();
        stateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, GetXDirection() * stateMachine.MoveSpeed / 11f);
    }

    public override void Tick(float deltaTime)
    {
        float normalizedTime = GetNormalizedTime(stateMachine.Animator, AttackAnimationTag);

        if (normalizedTime >= previousFrameTime && normalizedTime <= 1f)
        {
            if (stateMachine.InputReader.IsAttack)
            {
                TryCombo(previousFrameTime, attack.AttackAnimationNextIndex, stateMachine.Attacks);
                stateMachine.InputReader.IsAttack = false;
            }
        }
        else
        {
            stateMachine.ReturnLocomotion();
        }
        previousFrameTime = normalizedTime;
    }

    public override void Exit()
    {

    }

    void TryCombo(float normalizedTime, int nextIndex, Attacks[] attackComboList)
    {
        if (attack.AttackAnimationNextIndex == -1) { return; }
        if (normalizedTime < attack.AttackAnimationTime) { return; }

        stateMachine.SwitchState(new PlayerAttackState(
            stateMachine,
            nextIndex,
            attackComboList
        ));
    }

}

