// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/Input/InputSettings.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSettings : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSettings()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSettings"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6cecbe25-88a8-4e3c-9c15-20fa89b10b05"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""b7aab32c-f5b6-4b43-b2f7-fab6e4700106"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""56cd3bd1-fc24-45fa-bbe0-68285740da63"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""61ccb3f7-d720-480b-b3a9-657c9fa31efa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""01f155a3-c369-4391-875c-3fd599e40a68"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnToAsh"",
                    ""type"": ""Button"",
                    ""id"": ""b6f9cace-37d2-452d-b9d8-daf45ae221af"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5b6c9619-e7c4-478a-abf5-47e2440b1bb7"",
                    ""path"": ""1DAxis(whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""4a10e794-9af1-40ff-a76b-696ae9182aac"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""9fbcecb1-049b-4c77-8493-88023e8c5cdc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""306d8f96-37fd-4e11-9cfb-47b8881289a5"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f02140ce-2fdf-4537-a271-d789284187f2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Key&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdc525de-82d4-4399-994e-ea5317cd1988"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0fd56a5-6116-450e-830b-aa0ac2f4954b"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnToAsh"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Ashen Player"",
            ""id"": ""115ba464-86c3-4157-beb1-17a9be6f05cc"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4d0e76d9-a0f8-46b7-8942-f608a93acdf1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TurnToHuman"",
                    ""type"": ""Button"",
                    ""id"": ""4e092ff0-77fe-4e82-9ff1-a0636402b6f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cedd8043-4ff7-476e-bab5-44f190c5f7ca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""f687bd2b-e1d2-4d33-81fc-ff0b558bb41c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""433b57c9-938b-495c-a3be-819f279769f7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""9843d5e4-c2a1-4605-abfe-e46381e10aaa"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""653401ee-bcb3-4bab-bddf-de6d4b3cf2db"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4d2e432b-55ab-4113-a94d-b8aa2d99057c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TurnToHuman"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Key&Mouse"",
            ""bindingGroup"": ""Key&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_TurnToAsh = m_Player.FindAction("TurnToAsh", throwIfNotFound: true);
        // Ashen Player
        m_AshenPlayer = asset.FindActionMap("Ashen Player", throwIfNotFound: true);
        m_AshenPlayer_Move = m_AshenPlayer.FindAction("Move", throwIfNotFound: true);
        m_AshenPlayer_TurnToHuman = m_AshenPlayer.FindAction("TurnToHuman", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_TurnToAsh;
    public struct PlayerActions
    {
        private @InputSettings m_Wrapper;
        public PlayerActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @TurnToAsh => m_Wrapper.m_Player_TurnToAsh;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Sprint.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSprint;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @TurnToAsh.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnToAsh;
                @TurnToAsh.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnToAsh;
                @TurnToAsh.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTurnToAsh;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @TurnToAsh.started += instance.OnTurnToAsh;
                @TurnToAsh.performed += instance.OnTurnToAsh;
                @TurnToAsh.canceled += instance.OnTurnToAsh;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Ashen Player
    private readonly InputActionMap m_AshenPlayer;
    private IAshenPlayerActions m_AshenPlayerActionsCallbackInterface;
    private readonly InputAction m_AshenPlayer_Move;
    private readonly InputAction m_AshenPlayer_TurnToHuman;
    public struct AshenPlayerActions
    {
        private @InputSettings m_Wrapper;
        public AshenPlayerActions(@InputSettings wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_AshenPlayer_Move;
        public InputAction @TurnToHuman => m_Wrapper.m_AshenPlayer_TurnToHuman;
        public InputActionMap Get() { return m_Wrapper.m_AshenPlayer; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AshenPlayerActions set) { return set.Get(); }
        public void SetCallbacks(IAshenPlayerActions instance)
        {
            if (m_Wrapper.m_AshenPlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnMove;
                @TurnToHuman.started -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnTurnToHuman;
                @TurnToHuman.performed -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnTurnToHuman;
                @TurnToHuman.canceled -= m_Wrapper.m_AshenPlayerActionsCallbackInterface.OnTurnToHuman;
            }
            m_Wrapper.m_AshenPlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @TurnToHuman.started += instance.OnTurnToHuman;
                @TurnToHuman.performed += instance.OnTurnToHuman;
                @TurnToHuman.canceled += instance.OnTurnToHuman;
            }
        }
    }
    public AshenPlayerActions @AshenPlayer => new AshenPlayerActions(this);
    private int m_KeyMouseSchemeIndex = -1;
    public InputControlScheme KeyMouseScheme
    {
        get
        {
            if (m_KeyMouseSchemeIndex == -1) m_KeyMouseSchemeIndex = asset.FindControlSchemeIndex("Key&Mouse");
            return asset.controlSchemes[m_KeyMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnTurnToAsh(InputAction.CallbackContext context);
    }
    public interface IAshenPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTurnToHuman(InputAction.CallbackContext context);
    }
}
