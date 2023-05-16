using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Variables

    private int coinCount;

    #endregion

    #region Callbacks

    private void Start()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        
    }

    private void OnEnable()
    {
        EventManger.OnCollectCoin += ChangeCoinCount;
    }

    private void OnDisable()
    {
        EventManger.OnCollectCoin -= ChangeCoinCount;
    }

    #endregion

    #region OtherMethods

    private void ChangeCoinCount()
    {
        coinCount++;
        PlayerPrefs.SetInt("CoinCount", coinCount);
        coinCount = PlayerPrefs.GetInt("CoinCount");
    }

    #endregion
}
