using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUnpause : MonoBehaviour
{
   public static PauseUnpause PauseUnpauseInstance;

    private void Awake()
    {
        PauseUnpauseInstance = this;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }

    public bool IsPause()
    {
        if (Time.timeScale == 0)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    public void SlowMo(float amount)
    {
        Time.timeScale = amount;
    }
}
