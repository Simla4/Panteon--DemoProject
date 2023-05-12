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

    private Vector3 joystickDirection => JoystickBase.Instance.joystickDirection;
    
    private float sideMovementTarget;

    #endregion

    #region Callbacks

    private void Update()
    {
        MovePlayer();
    }

    #endregion

    #region OtherMethods

    private void MovePlayer()
    {
        var worldDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);
        transform.position += worldDirection * (speed * Time.deltaTime);
        var pos = transform.position;
        var newPosX = Mathf.Clamp(pos.x, -sideMovemntLimit, sideMovemntLimit);
        transform.position = new Vector3(newPosX, 0, transform.position.z);
    }
    #endregion
}
