using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Orc : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetPoint;
    public Animator animator;
    public Storage storage;
    public Wave wave;
    public TMP_Text enemyCountText;
    public void StartMove()
    {
        agent.destination = targetPoint.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Warrior>() && !agent.isStopped)
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
                wave.EndWave();
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
                wave.enemy -= storage.warrior;

                storage.warrior = 0;
                Invoke(nameof(Move), 2);
                wave.EndWave();
            }
            enemyCountText.text = wave.enemy.ToString();
        }
     
    }
    void Start()
    {
        enemyCountText.text = wave.enemy.ToString();
    }
    void Move()
    {
        agent.isStopped = false;

    }
    void Update()
    {
        if (agent.remainingDistance <= 0.03 && !agent.pathPending) 
        {
            storage.villager -= wave.enemy * 3;
            Time.timeScale = 0;
            wave.EndWave();
            Destroy(gameObject);
        }
    }
}
