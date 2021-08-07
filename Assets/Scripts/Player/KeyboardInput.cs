using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    private Vector3 _moveDirection;

    private bool _jump;
    private bool _sprint;

    private Mechanics _mechanics;

    public GameObject playerTurn;
    private bool playerTurned = false;

    private void Awake()
    {
        Controls.Instance.Enable();

        _mechanics = GetComponent<Mechanics>();

        Controls.Instance.Input.Player.Move.performed += context =>
        {
            var inputData = context.ReadValue<float>();
            _moveDirection = new Vector3(inputData, 0, 0);
        };

        //normal player
        Controls.Instance.Input.Player.Move.canceled += context => { _moveDirection = Vector3.zero; };
        Controls.Instance.Input.Player.Jump.performed += context => { _jump = true; };
        Controls.Instance.Input.Player.Jump.canceled += context => _jump = false;
        Controls.Instance.Input.Player.Sprint.performed += context => _sprint = true;
        Controls.Instance.Input.Player.Sprint.canceled += context => _sprint = false;
        Controls.Instance.Input.Player.TurnToAsh.performed += context => _mechanics.SetAsh();
        
        //ashen player
        Controls.Instance.Input.AshenPlayer.Move.performed += context =>
        {
            var inputData = context.ReadValue<float>();
            _moveDirection = new Vector3(inputData, 0, 0);
        };
        Controls.Instance.Input.AshenPlayer.Move.canceled += context => { _moveDirection = Vector3.zero; };
        Controls.Instance.Input.AshenPlayer.TurnToHuman.performed += context => _mechanics.SetHuman();
    }


    //Player turns other direction
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            playerTurned = true;
            playerDirection();
        }

        if (Input.GetKeyDown("d"))
        {
            playerTurned = false;
            playerDirection();
        }
    }

    public void playerDirection()
    {
        if (playerTurned)
        {
            playerTurn.transform.localRotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            playerTurn.transform.localRotation = Quaternion.Euler(0, 90, 0);
        }
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