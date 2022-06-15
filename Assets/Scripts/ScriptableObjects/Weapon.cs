using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon", fileName = "new Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Gun Data")]
    public float fireRate;
    public int damage;
    public GameObject projectile;
    public Sprite skin;
    [Header("Bullet Behavior")]
    public float bulletSpeed;
}
