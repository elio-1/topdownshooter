using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Enemy
{
    [HideInInspector] public int currentHealth;

    private void Awake()
    {
        currentHealth = enemyData.health;

    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
