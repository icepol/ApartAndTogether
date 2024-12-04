using UnityEngine;

public class DisableOnStart : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject);
    }
}
