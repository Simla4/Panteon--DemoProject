using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 8;
    [SerializeField] private Animator animator;

    [SerializeField] private Transform targetPoint;
    [SerializeField] private NavMeshAgent agent;

    #endregion

    #region Callbacks

    private void Start()
    {
        agent.SetDestination(targetPoint.position);
    }

    private void Update()
    {
        MoveAI();
    }

    #endregion

    #region MyRegion

    private void MoveAI()
    {
        animator.SetFloat("Speed", agent.speed);
    }
    
    #endregion
}
