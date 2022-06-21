using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth;
    [SerializeField] Character playerData;

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
