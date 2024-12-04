using System.Collections;
using pixelook;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private Transform spawningPointLeftTop;
    [SerializeField] private Transform spawningPointLeftBottom;
    [SerializeField] private Transform spawningPointRightTop;
    [SerializeField] private Transform spawningPointRightBottom;
    
    [SerializeField] private Enemy[] enemiesPrefabs;
    [SerializeField] private float spawnDelaySeconds = 1f;
    [SerializeField] private float spawnProbability = 0.5f;
    
    private int _enemiesCount;

    private void OnEnable()
    {
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.AddListener(Events.ENEMY_SPAWNED, OnEnemySpawned);
        EventManager.AddListener(Events.ENEMY_DIED, OnEnemyDied);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.RemoveListener(Events.ENEMY_SPAWNED, OnEnemySpawned);
        EventManager.RemoveListener(Events.ENEMY_DIED, OnEnemyDied);
    }
    
    private void OnGameStarted()
    {
        StartCoroutine(SpawnEnemy());
    }

    void OnEnemySpawned()
    {
        _enemiesCount++;
    }
    
    void OnEnemyDied()
    {
        _enemiesCount--;
    }
    
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelaySeconds);

            while (_enemiesCount >= MaxEnemiesCount())
            {
                yield return null;
            }
            
            if (!GameState.IsGameRunning) yield break;
        
            if (Random.Range(0f, 1f) > spawnProbability) continue;
            
            Spawn();
        }
    }

    void Spawn()
    {
        var randomEnemy = enemiesPrefabs[UnityEngine.Random.Range(0, enemiesPrefabs.Length)];
        var randomPosition = GetRandomPosition();
    
        var enemy = Instantiate(randomEnemy, randomPosition, Quaternion.identity);
        enemy.SetTargetPosition(GetTargetPosition(randomPosition));
    }
    
    Vector2 GetRandomPosition()
    {
        var randomX = Random.Range(0, 1) == 1 ? spawningPointLeftTop.position.x : spawningPointRightTop.position.x;
        var randomY = UnityEngine.Random.Range(spawningPointLeftBottom.position.y, spawningPointLeftTop.position.y);
        
        return new Vector2(randomX, randomY);
    }
    
    Vector2 GetTargetPosition(Vector2 startPosition)
    {
        return new Vector2(startPosition.x * -1f, startPosition.y);
    }
    
    int MaxEnemiesCount()
    {
        return GameState.CollectedCount switch
        {
            > 7 => 4,
            > 3 => 3,
            > 1 => 2,
            _ => 1
        };
    }
}
