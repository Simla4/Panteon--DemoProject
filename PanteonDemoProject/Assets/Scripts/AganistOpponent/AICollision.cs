using System;
using UnityEngine;

public class AICollision : MonoBehaviour
{
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
            EventManger.OnAICollisionRotatingPlatform?.Invoke();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        EventManger.OnAICollisionExitFromRotatingPlatform?.Invoke();
    }
}
