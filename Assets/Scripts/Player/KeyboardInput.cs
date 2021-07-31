using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private Vector3 _moveDirection;

    private bool _jump;
    private bool _sprint;

    private MechanicController _mechanicController;

    private void Awake()
    {
        _mechanicController = GetComponent<MechanicController>();
        
        Controls.Instance.Enable();

        Controls.Instance.Input.Player.Move.performed += context =>
        {
            var inputData = context.ReadValue<float>();
            _moveDirection = new Vector3(inputData, 0, 0);
        };

        Controls.Instance.Input.Player.Move.canceled += context => { _moveDirection = Vector3.zero; };

        Controls.Instance.Input.Player.Jump.performed += context => { _jump = true; };
        Controls.Instance.Input.Player.Jump.canceled += context => _jump = false;

        Controls.Instance.Input.Player.Sprint.performed += context => _sprint = true;
        Controls.Instance.Input.Player.Sprint.canceled += context => _sprint = false;
        
        Controls.Instance.Input.Player.TurnToAsh.performed += context => _mechanicController.ToggleAsh();
    }

    public float GetHorizontalMovementInput()
    {
        return _moveDirection.x;
    }

    public float GetVerticalMovementInput()
    {
        return _moveDirection.z;
    }

    public bool IsSprintKeyPressed()
    {
        return _sprint;
    }

    public bool IsJumpKeyPressed()
    {
        return _jump;
    }
}