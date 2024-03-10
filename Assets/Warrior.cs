using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPoint;
    public Animator animator;
    public void StartMove()
    {
        agent.destination = targetPoint.position;
    }
    public void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 2f);
    }

    public void Attack()
    {
        agent.isStopped = true;
        animator.SetTrigger("Attack");
    }

    void Update()
    {
        
    }
}
