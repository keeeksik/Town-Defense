using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Warrior : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPoint;
    void Start()
    {
        agent.destination = targetPoint.position;
    }

    void Update()
    {
        
    }
}
