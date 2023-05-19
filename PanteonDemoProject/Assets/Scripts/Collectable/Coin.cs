using System;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public void OnCollect()
    {
        EventManger.OnCollectCoin?.Invoke(gameObject.transform.position);
        gameObject.SetActive(false);
    }

    
    
}
