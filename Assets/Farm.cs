using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Farm : MonoBehaviour
{
    public Storage storage;
    public float currentTimer;
    public float startTimer;
    public TMP_Text farmTimerText;
    public AudioSource audioSource;
    public AudioClip audioClip;
    void Start()
    {
  
    }

    void Timer()
    {
        storage.wheat += storage.villager * 2;
        currentTimer = startTimer;
        audioSource.PlayOneShot(audioClip);
    }

    void Update()
    {

        if (currentTimer <= 0 )
        {
            Timer();
        }
        else 
        {
            currentTimer -= Time.deltaTime;
        }
        farmTimerText.text = Mathf.RoundToInt(currentTimer).ToString() + "s";
    }
}
