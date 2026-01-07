using System;
using UnityEngine;

public class SpotCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask LayerMask;

    [SerializeField] Transform wallCheckTransform;

    RaycastSensor spotCheckSensor;
    public bool isTouchSpot;
    public event Action OnTouchSpot;

    void Start()
    {
        spotCheckSensor = new RaycastSensor(gameObject.transform);
        spotCheckSensor.SetCastDirection(RaycastSensor.CastDirection.Right);
        spotCheckSensor.SetOffset(wallCheckTransform.position);
        spotCheckSensor.castLength = castLength;
        spotCheckSensor.layerMask = LayerMask;
    }

    void FixedUpdate()
    {
        spotCheckSensor.Cast();
        isTouchSpot = spotCheckSensor.HasDetected();
        if (isTouchSpot)
        {
            OnTouchSpot?.Invoke();
            // Debug.Log("Touch Wall");
        }
    }
}
