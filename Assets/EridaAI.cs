using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EridaAI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float chaseDistance = 5f;
    public float stopChaseDistance = 7f;

    private Transform player;
    private NavMeshAgent agent;
    private int currentPatrolIndex;
    private bool isChasing;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        isChasing = false;

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    private void Update()
    {
        if (isChasing)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stopChaseDistance)
            {
                isChasing = false;
                Patrol();
            }
            else
            {
                agent.SetDestination(player.position);
            }
        }
        else
        {
            Patrol();
        }
    }

    public void StartChasing()
    {
        isChasing = true;
        agent.SetDestination(player.position);
    }

    public void StopChasing()
    {
        isChasing = false;
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }
}
