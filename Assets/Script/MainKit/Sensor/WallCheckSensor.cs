using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class WallCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform wallCheckTransform;
    [SerializeField] BoxCollider2D box;

    RaycastSensor wallcastSensor;

    public bool isTouchWall; //{ get; private set; }
    public event Action OnTouchWall;

    void Start()
    {
        wallcastSensor = new(gameObject.transform, box);
        wallcastSensor.SetCastDirection(RaycastSensor.CastDirection.Right);
        wallcastSensor.SetOffset(wallCheckTransform.position);
        wallcastSensor.castLength = castLength;
        wallcastSensor.layerMask = layerMask;

    }

    void FixedUpdate()
    {
        wallcastSensor.Cast();
        isTouchWall = wallcastSensor.HasDetected();
        if (isTouchWall)
        {
            OnTouchWall?.Invoke();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
    }
}
