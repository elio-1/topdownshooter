using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character", fileName = "new Character")]
public class Character : ScriptableObject
{
    public string charName;
    public int health;
    public float speed;
    public int baseAttack;
    public int baseDefence;
    public float attackSpeed;
    public int experience;
}
