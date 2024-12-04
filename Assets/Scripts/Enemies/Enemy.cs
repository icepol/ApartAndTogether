using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void SetTargetPosition(Vector2 targetPosition)
    {
        var bird = GetComponent<Bird>();
        if (bird != null)
        {
            bird.SetTargetPosition(targetPosition);
        }
    }
}
