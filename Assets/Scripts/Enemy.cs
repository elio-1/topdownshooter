using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Maxhealth;
    public int currentHealth;
    public float speed;
    private void Awake()
    {
        currentHealth = Maxhealth;
    }
}
