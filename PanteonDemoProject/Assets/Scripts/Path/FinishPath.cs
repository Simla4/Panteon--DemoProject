using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPath : MonoSingleton<FinishPath>
{
    [SerializeField] private Transform finishPathTransform;

    public Transform FinishPathTransform => finishPathTransform;

}
