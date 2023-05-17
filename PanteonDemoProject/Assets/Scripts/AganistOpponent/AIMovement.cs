using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 8;
    [SerializeField] private Animator animator;

    #endregion

    #region Callbacks

    private void Update()
    {
        MoveAI();
    }

    #endregion

    #region MyRegion

    private void MoveAI()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        
        animator.SetFloat("Speed", speed);
    }
    
    

    #endregion
}
