using UnityEngine;

public class RootEntry : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _spriteRenderer.flipX = Random.value > 0.5f;
    }
}
