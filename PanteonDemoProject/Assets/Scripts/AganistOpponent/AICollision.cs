using System;
using UnityEngine;

public class AICollision : MonoBehaviour
{
    [SerializeField] private AIMovement aiMovement;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            obstacle.OnCharacterCollisionWithObstacle(gameObject);
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
