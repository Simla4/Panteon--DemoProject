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
    [SerializeField] private Canvas canvas;
    [SerializeField] private float coinSpawnOffset = 2;
    
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

    private Vector3 WorldToUISpace(Vector3 worldPosition)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);            
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPos, canvas.worldCamera, out Vector2 localPoint);
        return canvas.transform.TransformPoint(localPoint);
    }

    IEnumerator MoveCoinNumerator(Vector3 spawnPos)
    {

        for (int i = 0; i < coinCount; i++)
        {
            var coin = coinPool.Spawn();
            coin.transform.SetParent(coinParent);
            coin.transform.position = WorldToUISpace(spawnPos + Vector3.up * coinSpawnOffset);
            
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
