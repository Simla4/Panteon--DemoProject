using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject paintUI;
    [SerializeField] private GameObject inGametUI;

    [SerializeField] private TextMeshProUGUI coinTxt;
    [SerializeField] private TextMeshProUGUI deathCountTxt;
    [SerializeField] private TextMeshProUGUI rankTxt;

    #endregion

    #region Callbacks

    private void Start()
    {
        coinTxt.text = PlayerPrefs.GetInt("CoinCount").ToString();
    }

    private void OnEnable()
    {
        EventManger.OnMoveCoin += ChangeCoinTxt;
        EventManger.OnDeathCountChanged += ChangeDeathCountTxt;
        EventManger.OnPlayerReachFinish += ShowPaintUI;
        EventManger.OnPlayerRankChanged += ChangePlayerRankTxt;
    }

    private void OnDisable()
    {
        EventManger.OnMoveCoin -= ChangeCoinTxt;
        EventManger.OnDeathCountChanged -= ChangeDeathCountTxt;
        EventManger.OnPlayerReachFinish -= ShowPaintUI;
        EventManger.OnPlayerRankChanged -= ChangePlayerRankTxt;
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

    private void ChangePlayerRankTxt(int rank)
    {
        rankTxt.text = (rank + 1).ToString();
    }

    private void ShowPaintUI()
    {
        inGametUI.SetActive(false);
        paintUI.SetActive(true);
    }
    

    #endregion
}
