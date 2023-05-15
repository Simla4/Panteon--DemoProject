using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI coinTxt;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManger.OnCollectCoin += ChangeCoinTxt;
    }

    private void OnDisable()
    {
        EventManger.OnCollectCoin -= ChangeCoinTxt;
    }

    #endregion

    #region OtherMethods

    private void ChangeCoinTxt()
    {
        coinTxt.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }

    #endregion
}
