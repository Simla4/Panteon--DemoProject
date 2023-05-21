using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float rotationSpeed = 50;
    [SerializeField] private float sideMovementLimit;

    [SerializeField] private Animator animator;

    private Vector3 joystickDirection => JoystickBase.Instance.joystickDirection;

    #endregion

    #region Callbacks

    private void Update()
    {
        MovePlayer();
        ControlYAxis();
    }

    #endregion

    #region OtherMethods

    private void MovePlayer()
    {
        var worldDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);
        transform.position += worldDirection * (speed * Time.deltaTime);
        var pos = transform.position;
        var newPosX = Mathf.Clamp(pos.x, -sideMovementLimit, sideMovementLimit);
        transform.position = new Vector3(newPosX, pos.y, pos.z);

        animator.SetFloat("Speed", Mathf.Abs(joystickDirection.y));
        
        if (joystickDirection != Vector3.zero)
        {
            Quaternion newRotation = GetRotation();
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void ControlYAxis()
    {
        if (transform.position.y <= -5f)
        {
            transform.position = Vector3.zero;
            EventManger.OnCollisionObstacle?.Invoke();
        }
            
    }
    
    private Quaternion GetRotation()
    {
        float angle = Mathf.Atan2(joystickDirection.x, joystickDirection.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, angle, 0);

        return rotation;
    }

    #endregion
}
