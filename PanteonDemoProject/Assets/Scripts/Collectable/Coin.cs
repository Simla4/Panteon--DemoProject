using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    [SerializeField] private Transform targetPoint;

    private float screenWidth, screenHeight;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    public void OnCollect()
    {
        EventManger.OnCollectCoin?.Invoke();
        MoveCoin();
    }

    private void MoveCoin()
    {
        Debug.Log("pos: " + targetPoint.position);
        transform.DOLocalMove(targetPoint.position, 0.5f)
            .OnComplete(() =>
            {
                gameObject.SetActive(false);
            });

    }
}
