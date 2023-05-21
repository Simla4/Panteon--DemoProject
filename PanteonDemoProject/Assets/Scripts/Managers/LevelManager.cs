using System;
using System.Collections;
using System.Collections.Generic;
using PaintIn3D.Examples;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<GameObject> levels = new List<GameObject>();

    [SerializeField] private NavMeshSurface navMeshSurface;
    [SerializeField] private P3dChannelCounterText channelCounterText;

    private int currentLevel;
    private bool isPaintingActive = false;

    #endregion

    #region Callbacks

    private void Update()
    {
        if (isPaintingActive == true)
        {
            if (channelCounterText.DecimalPlaces >= 100)
            {
                EventManger.OnLevelCompleted?.Invoke();
            }
        }
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        levels[currentLevel].SetActive(true);
        StartCoroutine(BuildNavMeshPath());
    }

    private void OnEnable()
    {
        EventManger.OnNextLevel += ChangeLevel;
        EventManger.OnPlayerReachFinish += ChangeIsPaintingActiveStatus;
    }

    private void OnDisable()
    {
        EventManger.OnNextLevel -= ChangeLevel;
        EventManger.OnPlayerReachFinish -= ChangeIsPaintingActiveStatus;
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

        StartCoroutine(BuildNavMeshPath());

        isPaintingActive = false;
        
        EventManger.OnLoadedNextLevel?.Invoke();
        
    }

    IEnumerator BuildNavMeshPath()
    {
        yield return new WaitForSeconds(0.25f);
        navMeshSurface.BuildNavMesh();
    }

    private void ChangeIsPaintingActiveStatus()
    {
        isPaintingActive = true;
    }

    #endregion
}
