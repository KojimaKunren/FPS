using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HpGauge : MonoBehaviour
{
    public Player player;

    int maxHp;
    int currentHp;

    public Slider slider;

    void Start()
    {
        slider.value = 1;
        int playerHp = player.hp;
        maxHp = playerHp;
    }

    void Update()
    {
        currentHp = player.hp;
        slider.value = (float)currentHp / (float)maxHp;
    }
}
