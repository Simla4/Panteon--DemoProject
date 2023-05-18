using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacle : MonoBehaviour, IObstacle
{
    public void OnCharacterCollisionWithObstacle(GameObject character)
    {
        character.transform.position = Vector3.zero;
    }
}
