using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int enemy;
    public Storage storage;
    public int wave;
    public float startTimer;
    public float currentTimer;
    void Start()
    {
        currentTimer = startTimer;
    }
    void Timer()
    {
       if (storage.warrior >= enemy)
        {
            storage.warrior -= enemy;
        }
        else if (storage.warrior - enemy < 0)
        {
            storage.villager -= enemy - storage.warrior * 3;
        }
        else if (storage.villager / 3 + storage.warrior < enemy)
        {
            TheEnd();
        }
    }
    void EndWave()
    {
        currentTimer = startTimer;
        wave++;
    }
    void TheEnd()
    {

    }
    void Update()
    {
        if (currentTimer <= 0)
        {
            Timer();
        }
        else
        {
            currentTimer -= Time.deltaTime;
        }
    }
}
