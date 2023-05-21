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

    [SerializeField] private NavMeshAgent agent;

    private Transform targetPoint;
    private Vector3 firstPos;

    #endregion

    #region Callbacks

    private void Start()
    {
        StartCoroutine(AsigdDataEnumerator());
    }

    private void Update()
    {
        AIAnimation();
        ControlYAxis();
    }

    private void OnEnable()
    {
        EventManger.OnLoadedNextLevel += ResetAI;
    }

    private void OnDisable()
    {
        EventManger.OnLoadedNextLevel -= ResetAI;

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

    private void ResetAI()
    {
        StartCoroutine(ResetAINumarator());
    }

    IEnumerator ResetAINumarator()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(true);
        agent.SetDestination(targetPoint.position);
        transform.position = firstPos;
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

    IEnumerator AsigdDataEnumerator()
    {
        yield return new WaitForSeconds(0.25f);
        
        targetPoint = FinishPath.Instance.FinishPathTransform;
        agent.SetDestination(targetPoint.position);
        agent.speed = speed;
        firstPos = transform.position;
    }
    
    #endregion
}
