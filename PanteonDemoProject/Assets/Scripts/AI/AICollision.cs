using System;
using UnityEngine;

public class AICollision : MonoBehaviour
{
    [SerializeField] private AIMovement aiMovement;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            obstacle.OnCharacterCollisionWithObstacle(gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
            aiMovement.StopAI();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            aiMovement.DisableNavMeshAgent();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            aiMovement.EnableNavMeshAgent();
        }
    }
}
