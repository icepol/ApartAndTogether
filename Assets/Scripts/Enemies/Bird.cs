using pixelook;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float maxSpeed = 0.1f;
    
    private Transform _transform;
    private Vector2 _targetPosition;
    private bool _isMoving;

    private void Awake()
    {
        _transform = transform;
    }

    private void Start()
    {
        EventManager.TriggerEvent(Events.ENEMY_SPAWNED);
    }

    private void Update()
    {
        if (!_isMoving) return;
        
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, maxSpeed * Time.deltaTime);
        
        spriteRenderer.flipX = _transform.position.x < _targetPosition.x;
        
        if (Vector2.Distance(transform.position, _targetPosition) > 0.1f) return;
        
        EventManager.TriggerEvent(Events.ENEMY_DIED);
        Destroy(gameObject);
    }

    public void SetTargetPosition(Vector2 targetPosition)
    {
        _targetPosition = targetPosition;
        _isMoving = true;
    }
}
