using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Facebook.WitAi;

public class ActivateVoice : MonoBehaviour
{
    [SerializeField]

    private Wit wit;

    void Update()
    {
        if (wit == null) wit = GetComponent<Wit>();
    }

    public void TriggerPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            WitActivate();
    }

    public void WitActivate()
    {
        wit.Activate();
       
    }
}
