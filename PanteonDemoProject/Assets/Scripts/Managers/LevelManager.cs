using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    private int currentLevel;

    #endregion

    #region Callbacks

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        levels[currentLevel].SetActive(true);
    }

    private void OnEnable()
    {
        EventManger.OnNextLevel += ChangeLevel;
    }

    private void OnDisable()
    {
        EventManger.OnNextLevel -= ChangeLevel;
    }

    #endregion

    #region OtherMethods

    private void ChangeLevel()
    {
        levels[currentLevel].SetActive(false);
        
        currentLevel++;

        if (currentLevel % levels.Count == 0)
        {
            currentLevel = 0;
        }
        
        levels[currentLevel].SetActive(true);
        
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        
        EventManger.OnLoadedNextLevel?.Invoke();
        
    }

    #endregion
}
