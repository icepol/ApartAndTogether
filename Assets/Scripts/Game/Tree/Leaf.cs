using System.Collections;
using pixelook;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private Vector2 force;
    [SerializeField] private float gravityScale = 1f;
    
    [SerializeField] private ParticleSystem collectedParticles;
    [SerializeField] private ParticleSystem failedParticles;
    
    private Vector2 _direction;
    
    private Rigidbody2D _body;
    private CircleCollider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CircleCollider2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _body.bodyType = RigidbodyType2D.Static;
        _collider.enabled = false;
    }

    private void Update()
    {
        if (!isActive) return;
        
        HandleControls();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<RootEntry>())
        {
            OnRootEntered();
            return;
        }

        if (other.GetComponent<Thorn>())
        {
            OnThornEntered();
            return;
        }
        
        if (other.GetComponent<Enemy>())
        {
            OnEnemyEntered();
            return;
        }
    }

    public void Activate()
    {
        isActive = true;
        
        transform.SetParent(null);

        StartCoroutine(WaitAndActivate());
    }
    
    IEnumerator WaitAndActivate()
    {
        yield return new WaitForSecondsRealtime(0.5f);

        if (!GameState.IsGameRunning) yield break;

        _collider.enabled = true;
        _body.bodyType = RigidbodyType2D.Dynamic;
        _body.gravityScale = gravityScale;
        
        _direction = new Vector2(force.x * (Random.Range(0f, 1f) > 0.5f ? 1 : -1), force.y);
        _body.AddForce(_direction, ForceMode2D.Impulse);
        _spriteRenderer.sortingOrder = 1;
        
        EventManager.TriggerEvent(Events.LEAF_ACTIVATED);
    }
    
    public void Deactivate()
    {
        isActive = false;
        
        _collider.enabled = false;
        _body.bodyType = RigidbodyType2D.Static;
    }

    private void HandleControls()
    {
        if (!Input.anyKeyDown) return;
        
        _direction *= new Vector2(-1, 1);
        _body.linearVelocity = Vector2.zero;
        _body.AddForce(_direction, ForceMode2D.Impulse);
        
        _body.angularVelocity = 0;
        _body.AddTorque(_direction.x > 1 ? 1 : -1, ForceMode2D.Impulse);
        
        EventManager.TriggerEvent(Events.MOVEMENT_CHANGED);
    }
    
    private void OnRootEntered()
    {
        if (!isActive) return;
        
        Deactivate();
        
        Instantiate(collectedParticles, transform.position, Quaternion.identity);
        
        GameState.Score += 10;
        GameState.CollectedCount++;

        EventManager.TriggerEvent(Events.LEAF_COLLECTED);

        Destroy(gameObject);
    }

    private void OnThornEntered()
    {
        if (!isActive) return;
        
        Deactivate();
        
        Instantiate(failedParticles, transform.position, Quaternion.identity);
        
        EventManager.TriggerEvent(Events.LEAF_FAILED);
        
        Destroy(gameObject);
    }

    private void OnEnemyEntered()
    {
        if (!isActive) return;
        
        Deactivate();
        
        Instantiate(failedParticles, transform.position, Quaternion.identity);
        
        EventManager.TriggerEvent(Events.ENEMY_COLLISION);
        
        Destroy(gameObject);
    }
}
