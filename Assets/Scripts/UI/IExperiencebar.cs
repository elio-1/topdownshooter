using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IExperiencebar : MonoBehaviour
{
    Slider _ExpSlider;
    void Awake()
    {
        _ExpSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        _ExpSlider.maxValue = PlayerExp.expToLevelUp;
        _ExpSlider.value = PlayerExp.experiencePoints;
    }
}
