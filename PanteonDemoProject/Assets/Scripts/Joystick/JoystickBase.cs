using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickBase : MonoSingleton<JoystickBase>,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joystickBase, joystickTip;

    [HideInInspector] public Vector3 joystickDirection;

    private void OnEnable()
    {
        EventManger.OnPlayerReachFinish += ResetJoystick;
    }

    private void OnDisable()
    {
        EventManger.OnPlayerReachFinish -= ResetJoystick;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ResetJoystick();
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystickTip.position = eventData.position;
        var offset = Vector3.ClampMagnitude(joystickTip.position - joystickBase.position, 60);
        joystickDirection = offset / 60;

        joystickTip.position = joystickBase.position + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    private void ResetJoystick()
    {
        joystickDirection = Vector3.zero;
        joystickTip.position = joystickBase.position;
        
    }
}
