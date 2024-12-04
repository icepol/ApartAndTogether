using pixelook;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject targetToFollow;

    [SerializeField] private bool followX;
    [SerializeField] private bool followY;
    [SerializeField] private bool followZ;

    private Vector3 _offsetPosition;
    private bool _isFollowing;

    private void OnEnable()
    {
        EventManager.AddListener(Events.PLAYER_INITIATED, OnPlayerInitiated);
    }

    private void FixedUpdate()
    {
        if (!_isFollowing) return;
        
        var position = _offsetPosition;

        if (followX)
            position.x += targetToFollow.transform.position.x;
        
        if (followY)
            position.y += targetToFollow.transform.position.y;
        
        if (followZ)
            position.z += targetToFollow.transform.position.z;

        transform.position = position;
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.PLAYER_INITIATED, OnPlayerInitiated);
    }

    private void OnPlayerInitiated(int playerId)
    {
        _offsetPosition = transform.position;
        _offsetPosition.z -= targetToFollow.transform.position.z;

        _isFollowing = true;
    }
}
