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
    [SerializeField] private P3dChannelCounter channelCounter;
    [SerializeField] private Transform levelParent;

    private int currentLevel;
    private bool isPaintingActive = false;
    private GameObject previousLevel;

    #endregion

    #region Callbacks

    private void Update()
    {
        if (isPaintingActive == true)
        {
            if (channelCounterText.GetCurrentPercent() >= 100)
            {
                EventManger.OnLevelCompleted?.Invoke();
            }
        }
    }

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 0);
        var level = Instantiate(levels[currentLevel], levelParent, true);
        previousLevel = level;
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
        previousLevel.SetActive(false);
        
        currentLevel++;

        if (currentLevel % levels.Count == 0)
        {
            currentLevel = 0;
        }

        var level = Instantiate(levels[currentLevel], levelParent, true);
        previousLevel = level;

        PlayerPrefs.SetInt("CurrentLevel", currentLevel);

        StartCoroutine(BuildNavMeshPath());

        isPaintingActive = false;
        
        ChangeAISetActive();
        
        EventManger.OnLoadedNextLevel?.Invoke();
        
    }

    IEnumerator BuildNavMeshPath()
    {
        yield return new WaitForSeconds(0.01f);
        navMeshSurface.BuildNavMesh();
    }

    private void ChangeIsPaintingActiveStatus()
    {
        isPaintingActive = true;
    }

    private void ChangeAISetActive()
    {
        var aiList = RankManager.Instance.CharactersTransforms;

        for (int i = 0; i < aiList.Count; i++)
        {
            aiList[i].position = Vector3.zero;
            aiList[i].gameObject.SetActive(true);
        }
    }

    #endregion
}
