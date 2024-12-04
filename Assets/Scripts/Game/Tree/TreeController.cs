using System.Linq;
using pixelook;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    LeafPlaceholder[] _leavesPlaceholders;
    
    void OnEnable()
    {
        _leavesPlaceholders = FindObjectsByType<LeafPlaceholder>(FindObjectsSortMode.None);
        
        EventManager.AddListener(Events.LEAF_COLLECTED, OnLeafCollected);
        EventManager.AddListener(Events.LEAF_FAILED, OnLeafFailed);
        EventManager.AddListener(Events.ENEMY_COLLISION, OnEnemyCollision);
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.LEAF_COLLECTED, OnLeafCollected);
        EventManager.RemoveListener(Events.LEAF_FAILED, OnLeafFailed);
        EventManager.RemoveListener(Events.ENEMY_COLLISION, OnEnemyCollision);
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
    }
    
    void OnGameStarted()
    {
        ActivateLeaf();
    }

    void OnLeafCollected()
    {
        ActivateLeaf();
        SpawnLeaf();
    }

    void OnLeafFailed()
    {
        GameState.Lives--;
        
        if (GameState.Lives > 0)
            ActivateLeaf();
    }
    
    void OnEnemyCollision()
    {
        OnLeafFailed();
    }

    void OnGameOver()
    {
        // TODO: visual effect
    }
    
    void OnGameFinished()
    {
        // TODO: visual effect
    }

    private void ActivateLeaf()
    {
        // activate next leaf
        var possibleLeafPlaceholders = _leavesPlaceholders.Where(
                leafPlaceholder => leafPlaceholder.HasLeaf()
            ).ToList();
        
        
        if (possibleLeafPlaceholders.Count == 0)
        {
            // all leafs collected
            EventManager.TriggerEvent(Events.GAME_FINISHED);
            return;
        }
        
        possibleLeafPlaceholders[Random.Range(0, possibleLeafPlaceholders.Count)].ActivateLeaf();
    }

    private void SpawnLeaf()
    {
        if (!GameState.IsGameRunning) return;
        
        if (Random.Range(0f, 1f) > 0.5f) return;

        var emptyLeafPlaceholders = _leavesPlaceholders.Where(
                leafPlaceholder => !leafPlaceholder.HasLeaf()
            ).ToList();
        
        var leafPlaceholder = emptyLeafPlaceholders[Random.Range(0, emptyLeafPlaceholders.Count)];
        leafPlaceholder.SpawnLeaf();
    }
}
