
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public Storage storage;
    bool timerGo;
    float timerCurrent;
    float reachTime;
    public float startTimer;
    public TMP_Text eatTimerText;
    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
        StartTimer();
    }
    void TimerBreak()
    {
        audioSource.PlayOneShot(audioClip);
        timerGo = false;
        timerCurrent = 0;
        if (storage.wheat >= storage.warrior)
        {
            storage.wheat -= storage.warrior;
        }
        else if (storage.wheat == 0)
        {
            storage.warrior = 0;
        }
        else if (storage.wheat == 1)
        {
            storage.warrior -= storage.warrior - 1;
            storage.wheat -= 1;
        }
        else
        {
            storage.warrior -= storage.warrior % storage.wheat;
            storage.wheat -= storage.warrior;
        }
        
        StartTimer();
    }
    void StartTimer()
    {
      timerGo = true;
        reachTime = Time.time + startTimer;
    }
    void Update()
    {
        if (timerGo && reachTime - startTimer + timerCurrent < reachTime)
        {
            timerCurrent += Time.deltaTime;

        }
        else if (reachTime - startTimer + timerCurrent >= reachTime && timerGo)
        {
            TimerBreak();

        }
        eatTimerText.text = Mathf.RoundToInt(startTimer - timerCurrent).ToString() + "s";
    }
}

