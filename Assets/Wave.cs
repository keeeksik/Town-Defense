using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public int enemy;
    public Storage storage;
    public int wave;
    public float startTimer;
    public float currentTimer;
    public Transform spawnpointWarrior;
    public Transform spawnpointOrc;
    public GameObject warriorPrefab;
    public GameObject orcPrefab;
    public bool isTimerEnd;
    public Transform centerPoint;
    public Transform castlePoint;
    public TMP_Text textMeshPro;

    void Start()
    {
        currentTimer = startTimer;

    }
    void Timer()
    {
        if (storage.warrior > 0)
        {
           Warrior warrior = Instantiate(warriorPrefab, spawnpointWarrior.position, spawnpointWarrior.rotation).GetComponent<Warrior>();
            warrior.targetPoint = centerPoint;
           warrior.StartMove();
        }
        Orc orc = Instantiate(orcPrefab, spawnpointOrc.position, spawnpointOrc.rotation).GetComponent<Orc>();
        orc.storage = storage;
        orc.wave = this;
        if (storage.warrior >= 1)
        {
            orc.targetPoint = centerPoint;
        }
        else if (storage.warrior == 0)
        {

            orc.targetPoint = castlePoint;
        }
        orc.StartMove();
        isTimerEnd = true; 
    }
    public void EndWave()
    {
        currentTimer = startTimer;
        wave++;
        isTimerEnd= false;
        
    }
    void TheEnd()
    {

    }
    void Update()
    {
        if (currentTimer <= 0 && !isTimerEnd)
        {
            Timer();
        }
        else if (!isTimerEnd)
        {
            currentTimer -= Time.deltaTime;
        }

        textMeshPro.text = Mathf.RoundToInt(currentTimer).ToString() + "s";
    }
}

