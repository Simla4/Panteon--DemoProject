using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickBase : MonoSingleton<JoystickBase>,IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joystickBase, joystickTip;

    [HideInInspector] public Vector3 joystickDirection;

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickTip.position = joystickBase.position;
        joystickDirection = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        joystickTip.position = eventData.position;
        var offset = Vector3.ClampMagnitude(joystickTip.position - joystickBase.position, 100);
        joystickDirection = offset / 100;

        joystickTip.position = joystickBase.position + offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
