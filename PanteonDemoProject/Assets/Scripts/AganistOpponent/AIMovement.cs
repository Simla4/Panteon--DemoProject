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
        agent.speed = speed;
    }

    private void Update()
    {
        AIAnimation();
    }

    private void OnEnable()
    {
        EventManger.OnAICollisionRotatingPlatform += MoveAI;
        EventManger.OnAICollisionExitFromRotatingPlatform += ReturnNavMeshControl;
    }

    private void OnDisable()
    {
        EventManger.OnAICollisionRotatingPlatform -= MoveAI;
        EventManger.OnAICollisionExitFromRotatingPlatform -= ReturnNavMeshControl;
    }

    #endregion

    #region MyRegion

    private void AIAnimation()
    {
        animator.SetFloat("Speed", agent.speed);
    }

    private void MoveAI()
    {
        agent.enabled = false;
        transform.position += Vector3.forward * speed * Time.deltaTime; 
    }

    private void ReturnNavMeshControl()
    {
        agent.enabled = true;
        agent.SetDestination(targetPoint.position);
    }
    
    #endregion
}
