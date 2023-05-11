using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private Transform sideMovementRoot;
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float sideMovemntLimit;
    [SerializeField] private float sideMovementSensitivity;
    [SerializeField] private float sideMovementLerpSpeed;
    
    private float sideMovementTarget;

    #endregion

    #region Callbacks

    private void Update()
    {
        MoveForvard();
        SideMovement();
    }

    #endregion

    #region OtherMethods

    private void MoveForvard()
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime);
    }

    private void SideMovement()
    {
        sideMovementTarget += InputManager.Instance.inputDrag.x * sideMovementSensitivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, -sideMovemntLimit, sideMovemntLimit);
        var localPos = sideMovementRoot.localPosition;
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sideMovementLerpSpeed);
        sideMovementRoot.localPosition = localPos;
    }
    #endregion
}
