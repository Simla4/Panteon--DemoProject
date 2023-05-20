using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI coinTxt;
    [SerializeField] private TextMeshProUGUI deathCountTxt;

    #endregion

    #region Callbacks

    private void Start()
    {
        coinTxt.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }

    private void OnEnable()
    {
        EventManger.OnMoveCoin += ChangeCoinTxt;
        EventManger.OnCollisionObstacle += ChangeDeathCountTxt;
    }

    private void OnDisable()
    {
        EventManger.OnMoveCoin -= ChangeCoinTxt;
        EventManger.OnCollisionObstacle -= ChangeDeathCountTxt;
    }

    #endregion

    #region OtherMethods

    private void ChangeCoinTxt()
    {
        coinTxt.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }

    private void ChangeDeathCountTxt()
    {
        deathCountTxt.text = ScoreManager.Instance.DeathCount.ToString();
    }

    #endregion
}
