using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Weapon", fileName = "new Weapon")]
public class Weapon : ScriptableObject
{
    [Header("Gun Data")]
    public string gunName;
    public float fireRate;
    public int damage;
    public GameObject projectile;
    public Sprite skin;

    [Header("Bullet Behavior")]
    public string bulletName;
    public float bulletSpeed;

    [Header("CameraShake")]
    public float shakeMagnitude;
    public float shakeRoughness;
    public float shakeFadeInTime ;
    public float shakeFadeOutTime;
}
