using Unity.VisualScripting;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    Transform mainCamera;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] bckMaterials;
    float[] bckSpeed;

    [Range(0f, 0.5f)]
    [SerializeField] float parallaxSpeed;

    float fathestBack;

    void Start()
    {
        mainCamera = Camera.main.transform;
        camStartPos = mainCamera.position;
        int bckCount = transform.childCount;
        bckMaterials = new Material[bckCount];
        backgrounds = new GameObject[bckCount];
        bckSpeed = new float[bckCount];

        for (int i = 0; i < bckCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            bckMaterials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackGroundCalculateSpeed(bckCount);
    }


    void BackGroundCalculateSpeed(int bckCount)
    {
        for (int i = 0; i < bckCount; i++)
        {
            if (backgrounds[i].transform.position.z - mainCamera.transform.position.z > fathestBack)
            {
                fathestBack = backgrounds[i].transform.position.z - mainCamera.transform.position.z;
            }
        }

        for(int i = 0;i < bckCount; i++)
        {
            bckSpeed[i] = 1 - (backgrounds[i].transform.position.z - mainCamera.transform.position.z) / fathestBack;
        }
    }

    void LateUpdate()
    {
        distance = mainCamera.position.x - camStartPos.x;
        transform.position = new Vector3(mainCamera.position.x, transform.position.y, 0f);
        for (int i = 0; i < backgrounds.Length; i++) {
            float speed = bckSpeed[i] * parallaxSpeed;
            bckMaterials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }

    }
}
