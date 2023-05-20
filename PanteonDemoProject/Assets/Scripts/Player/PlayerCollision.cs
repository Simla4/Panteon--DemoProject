using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable collectable))
        {
            collectable.OnCollect();
        }

        if (other.gameObject.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            obstacle.OnCharacterCollisionWithObstacle(gameObject);
            EventManger.OnCollisionObstacle?.Invoke();
        }

        if (other.CompareTag("Finish"))
        {
            EventManger.OnPlayerReachFinish?.Invoke();
        }
    }
}
