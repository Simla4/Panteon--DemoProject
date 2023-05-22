using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    #region Variables

    private Vector3 firstPos;

    #endregion
    
    #region Callbacks

    private void Start()
    {
        firstPos = transform.position;
    }

    private void OnEnable()
    {
        EventManger.OnLoadedNextLevel += ResetPlayer;
    }

    private void OnDisable()
    {
        EventManger.OnLoadedNextLevel -= ResetPlayer;
    }

    #endregion

    #region OtherMethods

    private void ResetPlayer()
    {
        transform.position = firstPos;
    }

    #endregion
}
