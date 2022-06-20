using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
{
    public int currentHealth;
    void Awake()
    {
        currentHealth = playerData.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("You lose");
        }
    }
}
