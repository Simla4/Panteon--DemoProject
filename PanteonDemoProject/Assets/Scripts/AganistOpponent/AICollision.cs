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
            Debug.Log(other.gameObject.name + "Stay (AI)");
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("RotatingPlatform"))
        {
            EventManger.OnAICollisionExitFromRotatingPlatform?.Invoke();
            Debug.Log(other.gameObject.name + "Exit");
        }
    }
}
