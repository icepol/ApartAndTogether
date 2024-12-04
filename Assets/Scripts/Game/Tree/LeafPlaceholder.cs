using System;
using System.Collections;
using pixelook;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class LeafPlaceholder : MonoBehaviour
{
    [SerializeField] Leaf[] _leafPrefabs;
    
    CinemachineCamera _camera;

    private void Awake()
    {
        // clean example leaf
        Destroy(GetComponentInChildren<Leaf>().gameObject);
    }

    void Start()
    {
        _camera = FindAnyObjectByType<CinemachineCamera>();
        
        if (Random.Range(0f, 1f) > 0.5f)
        {
            var leaf = Instantiate(_leafPrefabs[Random.Range(0, _leafPrefabs.Length)], transform);
            leaf.transform.position = transform.position;
        }
    }
    
    public bool HasLeaf()
    {
        return transform.childCount > 0;
    }

    public void ActivateLeaf()
    {
        var leaf = GetComponentInChildren<Leaf>();
        
        _camera.Follow = leaf.transform;
        
        leaf.Activate();
    }
    
    public void SpawnLeaf()
    {
        StartCoroutine(SpawnDelayed());
    }

    IEnumerator SpawnDelayed()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 5f));
        
        if (!GameState.IsGameRunning) yield break;
        
        Instantiate(_leafPrefabs[Random.Range(0, _leafPrefabs.Length)], transform);
        
        // TODO: particles
        // TODO: sound
    }
}
