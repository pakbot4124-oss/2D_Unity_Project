
using Unity.VisualScripting;
using UnityEngine;

public abstract class State
{
    public abstract void Enter();

    public abstract void Exit();

    public abstract void Tick(float deltaTime);

    public abstract void PhysicsTick(float fixedDeltaTime);

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfor = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfor = animator.GetNextAnimatorStateInfo(0);

        if (animator.IsInTransition(0) && nextInfor.IsTag(tag))
        {
            return nextInfor.normalizedTime;
        }
        else if (!animator.IsInTransition(0) && currentInfor.IsTag(tag))
        {
            return currentInfor.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}
