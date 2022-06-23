using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum PlayerState
{
    Alive,
    Dead
}

public class PlayerHealth : MonoBehaviour
{
    public static int currentHealth;
    [SerializeField] Character playerData;
    [SerializeField] UnityEvent OnDeath = new UnityEvent();
    [HideInInspector] public static PlayerState currentState;
    void Awake()
    {
        currentHealth = playerData.health;
        currentState = PlayerState.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.currentHealth <= 0)
        {
            currentState = PlayerState.Dead;
        }
        else
        {
            currentState = PlayerState.Alive;
        }

        switch (currentState)
        {
            case PlayerState.Alive:
                break;
            case PlayerState.Dead:
                OnDeath.Invoke();
                break;
            default:
                break;
        }
    }
}
