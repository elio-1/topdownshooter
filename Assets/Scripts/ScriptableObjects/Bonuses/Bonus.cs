using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/Bonus", fileName = "newBonus")]
public class Bonus : ScriptableObject
{

    [Header("Shown In the UI")]
    public string m_title;
    public string m_description;
    public Sprite m_icon;
    [Header("Datas")]
    public Weapon weapon;
}
