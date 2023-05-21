using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject paintUI;
    [SerializeField] private GameObject inGametUI;
    [SerializeField] private GameObject starttUI;
    [SerializeField] private GameObject finishtUI;

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
        EventManger.OnPlayerRankChanged += ChangePlayerRankTxt;
        EventManger.OnPlayerReachFinish += ShowPaintUI;
        EventManger.OnGameStart += ShowInGameUI;
        EventManger.OnLevelCompleted += ShowFinishtUI;
    }

    private void OnDisable()
    {
        EventManger.OnMoveCoin -= ChangeCoinTxt;
        EventManger.OnDeathCountChanged -= ChangeDeathCountTxt;
        EventManger.OnPlayerReachFinish -= ShowPaintUI;
        EventManger.OnPlayerRankChanged -= ChangePlayerRankTxt;
        EventManger.OnGameStart -= ShowInGameUI;
        EventManger.OnLevelCompleted -= ShowFinishtUI;
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

    private void ShowStartUI()
    {
        starttUI.SetActive(true);
        finishtUI.SetActive(false);
    }
    
    private void ShowInGameUI()
    {
        inGametUI.SetActive(true);
        starttUI.SetActive(false);
    }
    
    private void ShowFinishtUI()
    {
        finishtUI.SetActive(true);
        paintUI.SetActive(false);
    }
    

    #endregion
}
