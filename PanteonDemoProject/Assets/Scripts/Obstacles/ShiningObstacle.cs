using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShiningObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private List<float> sideMovementLimit;

    private int nextPosIndex = 0;

    private void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        var pos = transform.position;
        
        if (pos.x == sideMovementLimit[nextPosIndex])
        {
            nextPosIndex++;
            if (nextPosIndex == sideMovementLimit.Count)
            {
                nextPosIndex = 0;
            }
            transform.DOMove(new Vector3(sideMovementLimit[nextPosIndex], pos.y, pos.z), 3);
        }
    }

    public void OnCharacterCollisionWithObstacle(GameObject character)
    {
        character.transform.position = Vector3.zero;
    }
}
