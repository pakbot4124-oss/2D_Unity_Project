using System;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]

public class SpotCheckSensor : MonoBehaviour
{
    [SerializeField] float castLength;
    [SerializeField] LayerMask LayerMask;
    [SerializeField] Transform wallCheckTransform;
    [SerializeField] BoxCollider2D box;

    RaycastSensor spotCheckSensor;

    public bool isTouchSpot; //{ get; private set; }
    public event Action OnTouchSpot;

    void Start()
    {
        spotCheckSensor = new RaycastSensor(gameObject.transform, box);
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
        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
    }
}
