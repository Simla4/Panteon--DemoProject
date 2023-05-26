using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 7;
    [SerializeField] private float sidewaySpeed = 5;
    [SerializeField] private Animator animator;

    private Vector3 firstPos;

    public float Speed => speed;

    #endregion

    #region Callbacks

    private void Start()
    {
        firstPos = transform.position;
    }

    private void Update()
    {
        MoveForward();
        ControlYAxis();
        AIAnimation();
    }

    private void OnEnable()
    {
        EventManger.OnLoadedNextLevel += ReturnToFirstPos;
    }

    private void OnDisable()
    {
        EventManger.OnLoadedNextLevel += ReturnToFirstPos;

    }

    #endregion

    #region OtherMethods

    private void MoveForward()
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime);
    }

    public void SideMovement()
    {
        if (transform.position.x < -1)
        {
            transform.position += Vector3.right * sidewaySpeed * Time.deltaTime;
        }
        else if(transform.position.x > 1)
        {
            transform.position += Vector3.left * sidewaySpeed * Time.deltaTime;

        }
    }
    
    private void ControlYAxis()
    {
        if (transform.position.y <= -3.5f)
        {
            ReturnToFirstPos();
        }
    }

    private void ReturnToFirstPos()
    {
        transform.position = firstPos;
    }

    private void AIAnimation()
    {
        animator.SetFloat("Speed", speed);
    }

    #endregion
}
