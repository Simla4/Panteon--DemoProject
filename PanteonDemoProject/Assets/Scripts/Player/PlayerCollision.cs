using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<ICollectable>(out ICollectable collectable))
        {
            collectable.OnCollect();
        }

        if (other.gameObject.TryGetComponent<IObstacle>(out IObstacle obstacle))
        {
            obstacle.OnCharacterCollisionWithObstacle(gameObject);
            EventManger.OnColiisionObstacle?.Invoke();
        }
    }
}
