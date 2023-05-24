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

    private void Start()
    {
        DisableJoystick();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        EnableJoystick();
        joystickBase.position = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        ResetJoystick();
        DisableJoystick();
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystickTip.position = eventData.position;
        var offset = Vector3.ClampMagnitude(joystickTip.position - joystickBase.position, 60);
        joystickDirection = offset / 60;

        joystickTip.position = joystickBase.position + offset;
    }


    private void ResetJoystick()
    {
        joystickDirection = Vector3.zero;
        joystickTip.position = joystickBase.position;
        DisableJoystick();
        
    }

    private void EnableJoystick()
    {
        joystickBase.gameObject.SetActive(true);
    }

    private void DisableJoystick()
    {
        joystickBase.gameObject.SetActive(false);
    }
}