using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolManager: MonoSingleton<PoolManager>
{
    public Pool<Coin> coinPool { get; } = new Pool<Coin>();
    [SerializeField] private Coin coinPrefab;

    private void Awake()
    {
        coinPool.Initialize(coinPrefab);
    }
}
