using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 8;
    [SerializeField] private float sidewaySpeed = 3;
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
        ControlYAxis();
    }

    #endregion

    #region MyRegion

    private void AIAnimation()
    {
        animator.SetFloat("Speed", agent.speed);
    }

    public void MoveAI()
    {
        agent.enabled = false;
        transform.position += Vector3.forward * speed * Time.deltaTime;


        if (transform.position.x < -1)
        {
            transform.position += Vector3.right * sidewaySpeed * Time.deltaTime;
        }
        else if(transform.position.x > 1)
        {
            transform.position += Vector3.left * sidewaySpeed * Time.deltaTime;

        }
    }

    public void ReturnNavMeshAgent()
    {
        agent.enabled = true;
        agent.SetDestination(targetPoint.position);
    }
    
    private void ControlYAxis()
    {
        if (transform.position.y <= -3.5f)
        {
            ReturnToStartPosition();
        }
            
    }

    private void ReturnToStartPosition()
    {
        transform.position = Vector3.zero;
        ReturnNavMeshAgent();
    }
    
    #endregion
}
