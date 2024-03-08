
using UnityEngine;
using UnityEngine.UI;

public class Hire : MonoBehaviour
{
    public Button hireButton;
    public Storage storage;
    public bool buyWarrior;
    bool timerGo;
    float timerCurrent;
    float reachTime;
    public float hireTime;
    void Start()
    {
        hireButton.onClick.AddListener(OnClick);

    }
    void OnClick()
    {
        if (!buyWarrior && storage.wheat >= 5)
        {
            storage.wheat -= 5;
            timerGo = true;
            hireButton.interactable = false;
            reachTime = Time.time + hireTime;

        }
        else if(storage.wheat >= 15)
        {
            storage.wheat -= 15;
            timerGo = true;
            hireButton.interactable = false;
            reachTime = Time.time + hireTime;
        }


    }
    void TimerBreak()
    {
        timerGo = false;
        timerCurrent = 0;
        if (buyWarrior)
        {
            storage.warrior++;
        }
        else
            storage.villager++;
    }
    void Update()
    {
        if (timerGo && reachTime-hireTime + timerCurrent < reachTime)
        {
            timerCurrent += Time.deltaTime;
            
        }
        else if (reachTime-hireTime + timerCurrent >= reachTime && timerGo)
        {
            hireButton.interactable = true;
            TimerBreak();
        }


    }
}
