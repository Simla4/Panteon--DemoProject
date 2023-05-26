using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private float speed = 8;
    [SerializeField] private float sidewaySpeed = 3;
    [SerializeField] private Animator animator;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform targetPoint;
    [SerializeField] private Rigidbody rb;
    private Vector3 firstPos;
    private float currentSpeed;

    #endregion

    #region Callbacks

    private void Start()
    {
        StartCoroutine(AsigdDataEnumerator());
        currentSpeed = agent.speed;
    }

    private void Update()
    {
        AIAnimation();
        ControlYAxis();
    }

    private void OnEnable()
    {
        EventManger.OnLoadedNextLevel += ResetAI;
        EventManger.OnPlayerReachFinish += StopAI;
        EventManger.OnGameStart += MoveAI;
    }

    private void OnDisable()
    {
        EventManger.OnLoadedNextLevel -= ResetAI;
        EventManger.OnPlayerReachFinish -= StopAI;
        EventManger.OnGameStart -= MoveAI;
    }

    #endregion

    #region MyRegion

    private void AIAnimation()
    {
        animator.SetFloat("Speed", speed);
    }

    public void DisableNavMeshAgent()
    {
        currentSpeed = agent.speed;
        agent.enabled = false;
        rb.isKinematic = false;
    }

    public void SideMovement()
    {
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

    public void StopAI()
    {
        agent.speed = 0;
    }

    private void MoveAI()
    {
        agent.speed = currentSpeed;
    }

    private void ResetAI()
    {
        StartCoroutine(ResetAINumarator());
    }

    IEnumerator ResetAINumarator()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(true);
        targetPoint = FinishPath.Instance.FinishPathTransform;
        agent.SetDestination(targetPoint.position);
        transform.position = firstPos;
    }

    public void EnableNavMeshAgent()
    {
        agent.enabled = true;
        rb.isKinematic = true;
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
        transform.position = firstPos;
        EnableNavMeshAgent();
    }

    IEnumerator AsigdDataEnumerator()
    {
        yield return new WaitForSeconds(0.05f);
        
        targetPoint = FinishPath.Instance.FinishPathTransform;
        agent.SetDestination(targetPoint.position);
        firstPos = transform.position;
    }
    
    #endregion
}
