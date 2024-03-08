using UnityEngine.UI;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public Storage storage;
    void Start()
    {
        InvokeRepeating(nameof(Timer), 1, 3);
    }
    void Timer()
    {
        storage.wheat += storage.villager * 2;
    }

    void Update()
    {
        
    }
}
