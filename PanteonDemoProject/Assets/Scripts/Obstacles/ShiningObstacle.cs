using System;
using UnityEngine;

public class ShiningObstacle : MonoBehaviour, IObstacle
{
    public void OnCharacterCollisionWithObstacle(GameObject character)
    {
        character.transform.position = Vector3.zero;
    }
}
