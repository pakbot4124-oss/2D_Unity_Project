using UnityEngine;

public abstract class EnemyBaseState : State
{
    public EnemyStateMachine enemyStateMachine;
    float magnitude;

    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        this.enemyStateMachine = enemyStateMachine;
    }


    protected void Chasing(Transform target, float fixedDeltaTime)
    {
        Vector2 direction = (target.transform.position - enemyStateMachine.transform.position).normalized;
        enemyStateMachine.ForceReceive.MoveVelocity(fixedDeltaTime, direction * enemyStateMachine.MoveSpeed);
    }

    protected void RotationToTarget()
    {
        Vector2 direction = (enemyStateMachine.Player.transform.position - enemyStateMachine.transform.position).normalized;
        Vector2 rotateByX = new(direction.x > 0 ? 1 : -1, 1f);
        enemyStateMachine.transform.localScale = rotateByX;
    }
    protected Vector2 GetXDirection()
    {
        if (enemyStateMachine.transform.localScale.x == -1)
        {
            return -enemyStateMachine.Rigidbody2D.transform.right;
        }
        else
        {
            return enemyStateMachine.Rigidbody2D.transform.right;
        }
    }

    protected void RotationToPatrol()
    {
        Vector2 rotateByX = new(enemyStateMachine.transform.localScale.x > 0 ? -1 : 1, 1f);
        enemyStateMachine.transform.localScale = rotateByX;
    }

    protected bool IsChasingZone()
    {
        magnitude = (enemyStateMachine.Player.transform.position - enemyStateMachine.transform.position).magnitude;
        return magnitude * magnitude <= enemyStateMachine.ChasingRadius * enemyStateMachine.ChasingRadius;
    }

    protected bool IsAttackZone()
    {
        magnitude = (enemyStateMachine.Player.transform.position - enemyStateMachine.transform.position).magnitude;
        return magnitude * magnitude <= enemyStateMachine.AttackRadius * enemyStateMachine.AttackRadius;
    }
}
