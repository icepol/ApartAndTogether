using pixelook;
using UnityEngine;

enum PickupType
{
    Immortality,
    Turbo,
    Bulldozer
}

public class Pickup : MonoBehaviour
{
    [SerializeField] private PickupType pickupType;
    [SerializeField] private ParticleSystem collectedParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        OnPlayer();
    }

    private void OnPlayer()
    {
        Instantiate(collectedParticles, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
