using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    #region Variables

    public Vector2 inputDrag;
    private Vector2 previousMousePosition;

    #endregion

    #region Callbacks

    private void Update()
    {
        HandleInput();
    }

    #endregion

    #region OtherMethods

    private Vector2 mousePositionCM
    {
        get
        {
            Vector2 pixels = Input.mousePosition;
            var inches = pixels / Screen.dpi;
            var centimeters = inches * 2.54f;

            return centimeters;
        }
    }


    public void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = mousePositionCM;
        }

        if (Input.GetMouseButton(0))
        {
            var deltaMouse = mousePositionCM - previousMousePosition;
            inputDrag = deltaMouse;
            previousMousePosition = mousePositionCM;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    #endregion
}
