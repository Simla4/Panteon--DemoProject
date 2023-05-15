using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void OnCollect()
    {
        EventManger.OnCollectCoin?.Invoke();
        gameObject.SetActive(false);
    }
    
}
