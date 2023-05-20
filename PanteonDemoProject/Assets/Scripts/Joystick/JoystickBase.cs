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
        joystickTip.anchoredPosition = eventData.position;
        var offset = Vector2.ClampMagnitude(joystickTip.anchoredPosition - joystickBase.anchoredPosition, 100);
        joystickDirection = offset / 100;

        joystickTip.anchoredPosition = joystickBase.anchoredPosition + (Vector2)offset;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
