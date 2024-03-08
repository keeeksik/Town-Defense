using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public int wheat;
    public int warrior;
    public int villager;
    public TMP_Text warriorCount;
    public TMP_Text wheatCount;
    public TMP_Text villagerCount;
    private void Update()
    {
         warriorCount.text = warrior.ToString();
         wheatCount.text = wheat.ToString();
         villagerCount.text = villager.ToString();
    }
}
