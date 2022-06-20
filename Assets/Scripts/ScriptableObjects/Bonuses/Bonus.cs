using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Data/Bonus", fileName = "new Bonus")]
public class Bonus : ScriptableObject
{
    public string m_title;
    public string m_description;
    public Sprite m_icon;
}
