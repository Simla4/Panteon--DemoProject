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
        animator.SetFloat("Speed", agent.speed);
    }

    public void DisableNavMeshAgent()
    {
        agent.speed = 0;
        agent.enabled = false;
    }

    public void SideMovement()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        
        animator.SetFloat("Speed", speed);

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
        agent.speed = 8;
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
        agent.speed = speed;
        animator.SetFloat("Speed", agent.speed);
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
        transform.position = transform.position;
        EnableNavMeshAgent();
    }

    IEnumerator AsigdDataEnumerator()
    {
        yield return new WaitForSeconds(0.05f);
        
        targetPoint = FinishPath.Instance.FinishPathTransform;
        agent.SetDestination(targetPoint.position);
        agent.speed = speed;
        firstPos = transform.position;
    }
    
    #endregion
}
