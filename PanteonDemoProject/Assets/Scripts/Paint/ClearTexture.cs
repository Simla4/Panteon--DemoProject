using System;
using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;

public class ClearTexture : MonoBehaviour
{
    [SerializeField] private P3dPaintableTexture paintableTexture;

    private void Start()
    {
        AssignPaintableTexture();
    }

    private void OnEnable()
    {
        EventManger.OnLevelCompleted += ResetTexture;
        EventManger.OnGameStart += AssignPaintableTexture;
    }

    private void OnDisable()
    {
        EventManger.OnLevelCompleted -= ResetTexture;
        EventManger.OnGameStart -= AssignPaintableTexture;
    }

    private void AssignPaintableTexture()
    {
        paintableTexture = PaintableObject.Instance.PaintableTexture;
    }

    private void ResetTexture()
    {
        paintableTexture.Clear();
    }
}
