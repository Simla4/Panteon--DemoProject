using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatorStick : MonoBehaviour, IObstacle
{
    [SerializeField] private float force = 5;
    [SerializeField] private float duration = 1;
    public void OnCharacterCollisionWithObstacle(GameObject character)
    {
        var targetPosZ = character.transform.position.z - force;
        var currentPos = character.transform.position;

        character.transform.DOMove(new Vector3(currentPos.x, currentPos.y, targetPosZ), duration);
    }
}
