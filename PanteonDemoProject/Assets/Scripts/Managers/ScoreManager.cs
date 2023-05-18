using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    #region Variables

    private int coinCount;
    private int deathCount = 0;

    public int DeathCount => deathCount;

    #endregion

    #region Callbacks

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        
    }

    private void OnEnable()
    {
        EventManger.OnCollectCoin += ChangeCoinCount;
        EventManger.OnColiisionObstacle += ChangeDeathCount;
    }

    private void OnDisable()
    {
        EventManger.OnCollectCoin -= ChangeCoinCount;
        EventManger.OnColiisionObstacle -= ChangeDeathCount;
    }

    #endregion

    #region OtherMethods

    private void ChangeCoinCount()
    {
        coinCount++;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinCount = PlayerPrefs.GetInt("CoinCount");
    }

    private void ChangeDeathCount()
    {
        deathCount++;
    }

    #endregion
}
