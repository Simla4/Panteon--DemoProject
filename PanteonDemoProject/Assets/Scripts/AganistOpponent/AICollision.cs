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
}
