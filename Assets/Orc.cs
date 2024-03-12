using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Orc : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPoint;
    public Animator animator;
    public Storage storage;
    public Wave wave;
    public void StartMove()
    {
        agent.destination = targetPoint.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Warrior>())
        {
            agent.isStopped = true;

            if (storage.warrior > wave.enemy)
            {
                other.GetComponent<Warrior>().Attack();
                animator.SetTrigger("Die");
                storage.warrior -= wave.enemy;
                wave.enemy = 0;
                Destroy(other.GetComponent<Warrior>().gameObject, 2f);
                Destroy(gameObject, 2f);
            }
            else if (storage.warrior == wave.enemy)
            {
                animator.SetTrigger("Attack");
                other.GetComponent<Warrior>().Attack();
                animator.SetTrigger("Die");
                storage.warrior -= wave.enemy;
                wave.enemy = 0;
                Destroy(gameObject, 2f);
                other.GetComponent<Warrior>().Die();
                wave.EndWave();
            }
            else if (storage.warrior < wave.enemy)
            {
                animator.SetTrigger("Attack");
                other.GetComponent<Warrior>().Die();
                storage.warrior = 0;
                wave.enemy -= storage.warrior;
                wave.EndWave();
            }
        }
     
    }
    void Update()
    {

    }
}
