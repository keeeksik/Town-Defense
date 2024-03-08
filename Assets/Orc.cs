using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orc : MonoBehaviour
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
