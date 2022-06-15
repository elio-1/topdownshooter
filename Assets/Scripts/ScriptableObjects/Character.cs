using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Character", fileName = "new Character")]
public class Character : ScriptableObject
{
    public int health;
    public float speed;
}
