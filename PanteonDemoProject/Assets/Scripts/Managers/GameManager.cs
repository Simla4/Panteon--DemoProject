using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Callbacks

    void Start()
    {
        StopGame();
    }

    #endregion

    #region OtherMethod

    public void StartGame()
    {
        Time.timeScale = 1;
        EventManger.OnGameStart?.Invoke();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        EventManger.OnNextLevel?.Invoke();
    }

    #endregion
    
}
