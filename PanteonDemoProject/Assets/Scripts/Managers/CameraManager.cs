using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] private CinemachineVirtualCamera paintableWallCamera;
    [SerializeField] private CinemachineVirtualCamera mainCamera;

    private void OnEnable()
    {
        EventManger.OnPlayerReachFinish += ActiveThePaintableWallCamera;
        EventManger.OnLoadedNextLevel += ActiveMainCamra;
    }

    private void OnDisable()
    {
        EventManger.OnPlayerReachFinish -= ActiveThePaintableWallCamera;
        EventManger.OnLoadedNextLevel -= ActiveMainCamra;
    }

    private void ActiveThePaintableWallCamera()
    {
        paintableWallCamera.Priority += 2;
    }

    private void ActiveMainCamra()
    {
        mainCamera.Priority += 2;
    }
}
