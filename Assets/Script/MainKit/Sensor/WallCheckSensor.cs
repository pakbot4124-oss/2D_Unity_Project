using System;
using UnityEngine;

public class WallCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Transform wallCheckTransform;
    RaycastSensor wallcastSensor;
    public bool isTouchWall;
    public event Action OnTouchWall;

    void Start()
    {
        wallcastSensor = new(gameObject.transform);
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
}
