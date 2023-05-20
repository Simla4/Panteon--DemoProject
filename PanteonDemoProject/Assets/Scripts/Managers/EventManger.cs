using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManger
{
    public static Action<Vector3> OnCollectCoin;
    public static Action OnMoveCoin;
    public static Action OnCollisionObstacle;
    public static Action OnDeathCountChanged;
    public static Action OnPlayerReachFinish;
    public static Action<int> OnPlayerRankChanged;
}
