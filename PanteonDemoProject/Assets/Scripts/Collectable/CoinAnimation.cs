using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

public class CoinAnimation : MonoBehaviour
{
    #region Variables

    [SerializeField] private RectTransform targetPos;
    [SerializeField] private float duration;
    [SerializeField] private int coinCount = 5;
    [SerializeField] private Transform coinParent;
    
    private Pool<MovableCoin> coinPool;

    #endregion

    #region Callbacks
    
    private void Start()
    {
        coinPool = PoolManager.Instance.coinPool;
    }

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

    private void MoveCoin(Vector3 spawnPos)
    {
        StartCoroutine(MoveCoinNumerator(spawnPos));
    }

    IEnumerator MoveCoinNumerator(Vector3 spawnPos)
    {

        for (int i = 0; i < coinCount; i++)
        {
            //Canvas.ForceUpdateCanvases();
            var coin = coinPool.Spawn();
            coin.transform.SetParent(coinParent);

            coin.transform.DOMove(targetPos.position, duration)
                .OnComplete(() =>
                {
                    EventManger.OnMoveCoin?.Invoke();
                    coinPool.ReturnToPool(coin);
                    
                });
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    #endregion
}
