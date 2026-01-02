using UnityEngine;

public class OnAttack : MonoBehaviour
{
    [SerializeField] GameObject attackObject;
    public void Enable()
    {
        attackObject.SetActive(true);
    }

    public void Disable()
    {
        attackObject.SetActive(false);
    }
}
