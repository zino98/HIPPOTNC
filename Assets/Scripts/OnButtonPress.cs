using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

/// <summary>
/// Checks for button input on an input action
/// </summary>
public class OnButtonPress : MonoBehaviour
{
    [Tooltip("Actions to check")]
    public InputAction action = null;

    // When the button is pressed
    public UnityEvent OnPress = new UnityEvent();

    private void Awake()
    {
        action.started += Pressed;
    }

    private void OnDestroy()
    {
        action.started -= Pressed;
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Pressed(InputAction.CallbackContext context)
    {
        OnPress.Invoke();
    }
}
