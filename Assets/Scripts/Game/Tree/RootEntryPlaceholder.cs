using UnityEngine;

public class RootEntryPlaceholder : MonoBehaviour
{
    [SerializeField] RootEntry[] rootEntryPrefabs;
    
    private RootEntry _rootEntry;
    
    private void Awake()
    {
        Destroy(GetComponentInChildren<RootEntry>().gameObject);
    }

    public void Activate()
    {
        _rootEntry = Instantiate(rootEntryPrefabs[Random.Range(0, rootEntryPrefabs.Length)], transform);
    }

    public void Deactivate()
    {
        if (_rootEntry == null) return;
        
        Destroy(_rootEntry.gameObject);
        _rootEntry = null;
    }
}
