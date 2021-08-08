using Sirenix.OdinInspector;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public enum PlayerState
    {
        Human,
        Ash
    }

    [SerializeField] private AudioClip toAsh;
    
    [SerializeField] private PlayerState state = PlayerState.Human;
    public PlayerState GetState() => state;

    private delegate void Mechanic();
    private Mechanic CurrentMechanic;

    [SerializeField, TabGroup("ASH")] private float ashHeight = 0.1f;
    [SerializeField, TabGroup("ASH")] private float ashSpeed = 3f;
    [SerializeField, TabGroup("ASH")] private float ashGravity = 3f;

    [SerializeField] private GameObject playerObject = null;
    [SerializeField] private GameObject ashObject = null;

    //store initial values
    private float _humanHeight = 0;
    private float _humanSpeed = 0;
    private float _humanGravity = 0;

    private AdvancedWalkerController _controller;
    protected void Awake()
    {
        _controller = GetComponent<AdvancedWalkerController>();
        _humanHeight = _controller.mover.colliderHeight;
        _humanSpeed = _controller.movementSpeed;
        _humanGravity = _controller.gravity;
    }

    private void Update()
    {
        CurrentMechanic?.Invoke();
    }

    public void SetAsh()
    {
        state = PlayerState.Ash;
                
        //adjust parameters
        _controller.mover.colliderHeight = ashHeight;
        _controller.movementSpeed = ashSpeed;
        _controller.gravity = ashGravity;
                
        //Disable controls
        Controls.Instance.Input.AshenPlayer.Enable();
        Controls.Instance.Input.Player.Disable();

        //attach update loop
        CurrentMechanic += Ash;
        
        _controller.mover.RecalculateColliderDimensions();
        
        playerObject.SetActive(false);
        ashObject.SetActive(true);
        
        GetComponent<AudioSource>().PlayOneShot(toAsh);
    }

    public void SetHuman()
    {
        state = PlayerState.Human;
                
        //adjust parameters
        _controller.mover.colliderHeight = _humanHeight;
        _controller.movementSpeed = _humanSpeed;
        _controller.gravity = _humanGravity;
                
        //Enable controls
        Controls.Instance.Input.AshenPlayer.Disable();
        Controls.Instance.Input.Player.Enable();

        //detach update loop
        CurrentMechanic -= Ash;
        
        _controller.mover.RecalculateColliderDimensions();
        
        ashObject.SetActive(false);
        playerObject.SetActive(true);
    }

    private void Ash()
    {

    }
}
