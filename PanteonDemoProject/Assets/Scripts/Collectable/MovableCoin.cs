using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableCoin : MonoBehaviour, IPool
{
    [SerializeField] private RectTransform rectTransform;
    
    public void OnPoolObjectSpawn()
    {
        gameObject.SetActive(true);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.anchoredPosition = new Vector2(6, -197f);
    }

    public void OnPoolObjectDestroy()
    {
        gameObject.SetActive(false);
        
        
    }
}
