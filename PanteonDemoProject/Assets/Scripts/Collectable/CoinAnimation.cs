using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    #region Variables

    [SerializeField] private RectTransform targeRectTransform;

    #endregion

    #region Callbacks

    private void OnEnable()
    {
        EventManger.OnCollectCoin += MoveCoin;
    }

    private void OnDisable()
    {
        EventManger.OnCollectCoin -= MoveCoin;
    }

    #endregion

    #region OtherMethods

    private void MoveCoin()
    {
        
    }

    #endregion
}
