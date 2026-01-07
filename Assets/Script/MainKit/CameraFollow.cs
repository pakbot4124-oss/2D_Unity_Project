using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Camera cameraFl;
    [SerializeField] Transform playerTr;

    void Start()
    {
        gameObject.transform.position = playerTr.position;
    }

    void LateUpdate()
    {

    }
}
