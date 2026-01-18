using UnityEngine;

public class RaycastSensor
{
    public float castLength = 1f;
    public LayerMask layerMask = 255;


    Vector2 offset = Vector2.zero;
    Transform subjectTransform;
    BoxCollider2D box;
    public enum CastDirection { Up, Down, Left, Right };
    CastDirection castDirection;

    RaycastHit2D hit;

    public RaycastSensor(Transform transform, BoxCollider2D box)
    {
        subjectTransform = transform;
        this.box = box;
    }


    public void SetOffset(Vector2 newOffset)
    {
        offset = subjectTransform.InverseTransformPoint(newOffset);
    }

    public void SetTrasnform(Transform transform)
    {
        subjectTransform = transform;
    }

    public bool HasDetected() => hit.collider != null;
    public float GetDisTance() => hit.distance;

    public void Cast()
    {
        Vector2 worldOrigin = subjectTransform.TransformPoint(offset);
        Vector2 worldDirection = GetCastDirection();
        hit = Physics2D.BoxCast(
            box.bounds.center, 
            box.bounds.size, 
            0f, 
            worldDirection, 
            castLength, 
            layerMask
            );
    }

    public void SetCastDirection(CastDirection castDirection)
    {
        this.castDirection = castDirection;
    }

    Vector2 GetCastDirection()
    {
        return castDirection switch
        {
            CastDirection.Up => subjectTransform.up,
            CastDirection.Down => -subjectTransform.up,
            CastDirection.Right => subjectTransform.right,
            CastDirection.Left => -subjectTransform.right,
            _ => Vector2.one,

        };
    }
}




