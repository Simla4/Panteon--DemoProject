using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RotatingPlatformPurple : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2;
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name + "Stay");
            var adjustSpeed = rotationSpeed * Time.deltaTime;
            other.transform.position += Vector3.right * adjustSpeed;
        }
        
    }
}
