using UnityEngine;

public abstract class PlayerBaseState : State
{
    public PlayerStateMachine stateMachine;
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }


    public void Rotation()
    {
        if (stateMachine.InputReader.MovementDirection.x != 0)
        {
            float currentDirection = stateMachine.InputReader.MovementDirection.x < 0 ? -1 : 1;
            Vector3 newLocalScale = new(currentDirection, 1f, 1f);
            stateMachine.transform.localScale = newLocalScale;
        }
    }


    public Vector2 GetDirByInput()
    {
        if(stateMachine.InputReader.MovementDirection == Vector2.zero)
        {
            return Vector2.zero;
        }

        return stateMachine.InputReader.MovementDirection.x < 0 ? Vector2.left : Vector2.right;
    }

    public Vector2 GetXDirection()
    {
        if (stateMachine.transform.localScale.x == -1)
        {
            return -stateMachine.Rigidbody2D.transform.right;
        }
        else
        {
            return stateMachine.Rigidbody2D.transform.right;
        }
    }
}
