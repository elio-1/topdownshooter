using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum bonusType
{
    Attack,
    Defense,
    Weapon,
    Speed
}
[CreateAssetMenu(menuName = "Data/Bonus", fileName = "newBonus")]
public class Bonus : ScriptableObject
{

    [Header("Shown In the UI")]
    public string m_title;
    public string m_description;
    public Sprite m_icon;
    [Header("Datas")]
    public bonusType m_currentBonusType;

    [Tooltip("Bonus value to add according to the current bonus type in the enum")] public int m_bonusValue;
    public Weapon weapon;
}
