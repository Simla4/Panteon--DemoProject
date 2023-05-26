using System;
using UnityEngine;
using UnityEngine.Serialization;

public class AICollision : MonoBehaviour
{
    [SerializeField] private AIMovement aıMovement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            obstacle.OnCharacterCollisionWithObstacle(gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            aıMovement.SideMovement();
        }
    }
}
