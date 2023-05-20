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
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            aiMovement.MoveAI();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            aiMovement.ReturnNavMeshAgent();
        }
    }
}
