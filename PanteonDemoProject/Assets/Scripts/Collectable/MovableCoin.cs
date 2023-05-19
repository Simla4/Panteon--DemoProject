using UnityEngine;

public class MovableCoin : MonoBehaviour, IPool
{
    [SerializeField] private RectTransform rectTransform;
    //[SerializeField] RectTransform spa
    
    public void OnPoolObjectSpawn()
    {
        gameObject.SetActive(true);
        // rectTransform.anchoredPosition = new Vector2(6, -197f);
    }

    public void OnPoolObjectDestroy()
    {
        gameObject.SetActive(false);
        
        
    }
}
