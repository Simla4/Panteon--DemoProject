using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AISensor : MonoBehaviour
{
    [SerializeField] private float sensorLenght = 3;
    [SerializeField] private float angle = 30;
    [SerializeField] private AIMovement aiMovement;

    private bool avoiding = false;

    private void FixedUpdate()
    {
        Sensors();
    }

    private void Sensors()
    {
        RaycastHit hit;
        var sensorStartPos = transform.position;
        float avoidMultipleyer = 0;

        avoiding = false;

        sensorStartPos.y += 1;
        
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(angle, transform.up) * Vector3.forward, out hit,
                sensorLenght))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.DrawRay(sensorStartPos,
                    Quaternion.AngleAxis(angle, transform.up) * Vector3.forward * hit.distance, Color.red);
                avoiding = true;
                avoidMultipleyer -= 1f;
            }
        }
        else if(Physics.Raycast(sensorStartPos, Vector3.right, out hit, sensorLenght/2))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                avoiding = true;
                avoidMultipleyer -= 1f;
            }
        }
        
        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-angle, transform.up) * Vector3.forward, out hit,
                sensorLenght))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.DrawRay(sensorStartPos,
                    Quaternion.AngleAxis(-angle, transform.up) * Vector3.forward * hit.distance, Color.red);
                avoiding = true;
                avoidMultipleyer += 1f;
            }
        }
        else if(Physics.Raycast(sensorStartPos, Vector3.left, out hit, sensorLenght/2))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                avoiding = true;
                avoidMultipleyer += 1f;
            }
        }

        if (avoiding)
        {
            var speed = aiMovement.Speed;
            transform.position += Vector3.right * (avoidMultipleyer * speed * Time.deltaTime); 
        }

    }
}
