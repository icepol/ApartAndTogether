using UnityEngine;

namespace pixelook
{
    public class CameraShake : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void OnMovingObstacleCollision()
        {
            _animator.SetTrigger("ShakeSmall");
        }

        private void OnStaticObstacleCollision()
        {
            _animator.SetTrigger("ShakeBig");
        }
    }
}