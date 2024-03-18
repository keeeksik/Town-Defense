using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
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
    public TMP_Text textWaveTimer;
    public int waveEnemyCount;
    public TMP_Text textEnemyWave;
    public TMP_Text textWave;
    public GameObject losePanel;
    public GameObject winPanel;
    public int wheatToWin;
    public int villagersToWin;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip2;

    void Start()
    {
        currentTimer = startTimer;
        textEnemyWave.text = "Enemies - " + waveEnemyCount.ToString();

    }
    void Timer()
    {
        if (storage.warrior > 0)
        {
           Warrior warrior = Instantiate(warriorPrefab, spawnpointWarrior.position, spawnpointWarrior.rotation).GetComponent<Warrior>();
            warrior.targetPoint = centerPoint;
           warrior.StartMove();
        }
        enemy = waveEnemyCount;
        Orc orc = Instantiate(orcPrefab, spawnpointOrc.position, spawnpointOrc.rotation).GetComponent<Orc>();
        orc.storage = storage;
        orc.wave = this;
        orc.targetPoint = castlePoint;
        audioSource.PlayOneShot(audioClip);
        orc.StartMove();
        isTimerEnd = true; 
    }
    public void EndWave()
    {
        currentTimer = startTimer;
        wave++;
        isTimerEnd= false;
        if (wave < 4)
        {
            waveEnemyCount = waveEnemyCount * 2;
        }
        else 
            waveEnemyCount = (int)(waveEnemyCount * 1.5f);
        textEnemyWave.text = "Enemies - " + waveEnemyCount.ToString();
        textWave.text = "Wave " + wave.ToString();
        if (storage.villager < 0)
        {
            TheEnd();
        }

    }
    
    void TheEnd()
    {
        losePanel.SetActive(true);
        audioSource.PlayOneShot(audioClip2);
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

        textWaveTimer.text = Mathf.RoundToInt(currentTimer).ToString() + "s";
        if (storage.villager >= villagersToWin && storage.wheat >= wheatToWin)
        {
            Win();
        }
    }
    void Win()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0; 
    }
}

