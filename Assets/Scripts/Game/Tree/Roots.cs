using pixelook;
using UnityEngine;

public class Roots : MonoBehaviour
{
    [SerializeField] private RootEntryPlaceholder[] rootEntryPlaceholders;

    private void OnEnable()
    {
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.AddListener(Events.LEAF_COLLECTED, OnLeafCollected);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.RemoveListener(Events.LEAF_COLLECTED, OnLeafCollected);
    }
    
    private void OnGameStarted()
    {
        ActivateRootEntry();
    }
    
    private void OnLeafCollected()
    {
        DisableAllRootEntries();
        ActivateRootEntry();
    }
    
    private void DisableAllRootEntries()
    {
        foreach (var rootEntryPlaceholder in rootEntryPlaceholders)
        {
            rootEntryPlaceholder.Deactivate();
        }
    }
    
    private void ActivateRootEntry()
    {
        rootEntryPlaceholders[Random.Range(0, rootEntryPlaceholders.Length)].Activate();
    }
}
