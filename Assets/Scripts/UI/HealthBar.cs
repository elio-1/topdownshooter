using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : PlayerHealth
{
    Slider Slider;
    void Awake()
    {
        Slider = GetComponent<Slider>();
        Slider.maxValue = playerData.health;
        Slider.minValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = currentHealth;
    }
}
