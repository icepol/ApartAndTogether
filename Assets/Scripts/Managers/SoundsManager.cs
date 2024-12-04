using UnityEngine;

namespace pixelook
{
    public class SoundsManager : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        
        [SerializeField] private AudioClip[] leafActivatedSounds;
        [SerializeField] private AudioClip[] leafCollectedSounds;
        [SerializeField] private AudioClip[] leafFailedSounds;
        [SerializeField] private AudioClip[] enemyCollisionSounds;
        [SerializeField] private AudioClip[] movementSounds;
        [SerializeField] private AudioClip gameOverSound;
        [SerializeField] private AudioClip gameFinishedSound;

        private void OnEnable()
        {
            EventManager.AddListener(Events.LEAF_ACTIVATED, OnLeafActivated);
            EventManager.AddListener(Events.LEAF_FAILED, OnLeafFailed);
            EventManager.AddListener(Events.LEAF_COLLECTED, OnLeafCollected);
            EventManager.AddListener(Events.ENEMY_COLLISION, OnEnemyCollision);
            EventManager.AddListener(Events.MOVEMENT_CHANGED, OnMovementChanged);
            EventManager.AddListener(Events.GAME_OVER, OnGameOver);
            EventManager.AddListener(Events.GAME_FINISHED, OnGameFinished);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(Events.LEAF_ACTIVATED, OnLeafActivated);
            EventManager.RemoveListener(Events.LEAF_FAILED, OnLeafFailed);
            EventManager.RemoveListener(Events.LEAF_COLLECTED, OnLeafCollected);
            EventManager.RemoveListener(Events.ENEMY_COLLISION, OnEnemyCollision);
            EventManager.RemoveListener(Events.MOVEMENT_CHANGED, OnMovementChanged);
            EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
            EventManager.RemoveListener(Events.GAME_FINISHED, OnGameFinished);
        }

        private void OnLeafActivated()
        {
            if (leafActivatedSounds.Length > 0 && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(leafActivatedSounds[Random.Range(0, leafActivatedSounds.Length)], targetTransform.position);
        }

        private void OnLeafCollected()
        {
            if (leafCollectedSounds.Length > 0 && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(leafCollectedSounds[Random.Range(0, leafCollectedSounds.Length)], targetTransform.position);
        }
        
        private void OnLeafFailed()
        {
            if (leafFailedSounds.Length > 0 && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(leafFailedSounds[Random.Range(0, leafFailedSounds.Length)], targetTransform.position);
        }
        
        private void OnEnemyCollision()
        {
            if (enemyCollisionSounds.Length > 0 && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(enemyCollisionSounds[Random.Range(0, enemyCollisionSounds.Length)], targetTransform.position);
        }
        
        private void OnMovementChanged()
        {
            if (movementSounds.Length > 0 && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(movementSounds[Random.Range(0, movementSounds.Length)], targetTransform.position);
        }
        
        private void OnGameOver()
        {
            if (gameOverSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(gameOverSound, targetTransform.position);
        }
        
        private void OnGameFinished()
        {
            if (gameFinishedSound && Settings.IsSfxEnabled)
                AudioSource.PlayClipAtPoint(gameFinishedSound, targetTransform.position);
        }
    }
}