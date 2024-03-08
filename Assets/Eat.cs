
using UnityEditor.SceneManagement;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public Storage storage;
    bool timerGo;
    float timerCurrent;
    float reachTime;
    public float eatTime;
    void Start()
    {
        StartTimer();
    }
    void TimerBreak()
    {
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
        reachTime = Time.time + eatTime;
    }
    void Update()
    {
        if (timerGo && reachTime - eatTime + timerCurrent < reachTime)
        {
            timerCurrent += Time.deltaTime;

        }
        else if (reachTime - eatTime + timerCurrent >= reachTime && timerGo)
        {
            TimerBreak();

        }
    }
}

