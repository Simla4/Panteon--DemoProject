using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    [SerializeField] private List<Transform> charactersTransforms = new List<Transform>();
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        FindPlayerRank();
    }

    private void FindPlayerRank()
    {
        for (int i = 0; i < charactersTransforms.Count - 1; i++)
        {
            for (int j = i + 1; j < charactersTransforms.Count; j++)
            {
                if (charactersTransforms[i].position.z < charactersTransforms[j].position.z)
                {
                    (charactersTransforms[i], charactersTransforms[j]) = (charactersTransforms[j], charactersTransforms[i]);
                }
            }
        }
        
        EventManger.OnPlayerRankChanged?.Invoke(charactersTransforms.IndexOf(playerTransform));
        
    }
}
