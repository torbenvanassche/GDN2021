using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable: SerializedMonoBehaviour
{
    private string _playerTag = "Player";

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
        {
            Controls.Instance.Input.Player.Interact.performed += Action;
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(_playerTag))
        {
            Controls.Instance.Input.Player.Interact.performed -= Action;
        }
    }
    
    protected virtual void Action(InputAction.CallbackContext context = default)
    {
    }
}
