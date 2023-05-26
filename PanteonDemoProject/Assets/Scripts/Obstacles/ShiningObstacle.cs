using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShiningObstacle : MonoBehaviour, IObstacle
{
    [SerializeField] private List<float> sideMovementLimit;
    [SerializeField] private new ParticleSystem particleSystem;

    private int nextPosIndex = 0;
    private ParticleSystem.MinMaxGradient firstColor;

    private void Update()
    {
        MoveObstacle();
        firstColor = particleSystem.main.startColor;
    }

    private void MoveObstacle()
    {
        var pos = transform.position;
        
        if (Mathf.Approximately(pos.x, sideMovementLimit[nextPosIndex]))
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
        StartCoroutine(ChangerParticleColor());
    }

    IEnumerator ChangerParticleColor()
    {
        var particleSystemMain = particleSystem.main;
        particleSystemMain.startColor = Color.red;
        yield return new WaitForSeconds(0.25f);
        particleSystemMain.startColor = firstColor;
    }
}
