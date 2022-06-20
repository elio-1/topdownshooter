using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IBonus : MonoBehaviour
{
    [SerializeField] Bonus bonusData;
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;

    private void Awake()
    {
        icon.overrideSprite = bonusData.m_icon;
        title.text = bonusData.m_title;
        description.text = bonusData.m_description;
    }
}
