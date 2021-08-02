using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable : SerializedMonoBehaviour
{
    private string _playerTag = "Player";
    [SerializeField] private bool invokeAlways = false;

    private delegate void CustomUpdate(InputAction.CallbackContext context);
    private CustomUpdate customUpdate;

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag) && !invokeAlways)
        {
            Controls.Instance.Input.Player.Interact.performed += Action;
        }
        else if (invokeAlways)
        {
            customUpdate += Action;
        }
    }

    protected virtual void Update()
    {
        customUpdate?.Invoke(new InputAction.CallbackContext());
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag) && !invokeAlways)
        {
            Controls.Instance.Input.Player.Interact.performed -= Action;
        }
        else if (invokeAlways)
        {
            customUpdate += Action;
        }
    }

    protected virtual void Action(InputAction.CallbackContext context = default)
    {
    }
}