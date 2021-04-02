// GENERATED AUTOMATICALLY FROM 'Assets/Code/Work/PlayerMini/PlayerMini_Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerMini_Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerMini_Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerMini_Control"",
    ""maps"": [
        {
            ""name"": ""PlayerMini"",
            ""id"": ""973de3f0-286a-415a-b060-8acc947b1065"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9c921c56-142a-463b-ad1c-6ec1bf4740b9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""8f716140-e7f8-47a5-8b7d-0e455fabdd4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Research"",
                    ""type"": ""Button"",
                    ""id"": ""83b235b3-3015-4bb9-9854-c05a43ec350b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot_Special"",
                    ""type"": ""Button"",
                    ""id"": ""fd0f8c20-7ada-4ee9-afdc-eeb8b0d22874"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""6753677b-022f-4f70-8e2f-e7cdcc04127e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6e1fa2f2-ba5b-4977-8374-e18b32480201"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e8a8cca4-dcb9-4108-8c8e-42276c69a03f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2d9bc973-34bc-49b4-8316-4212b9a40d92"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b47ef443-7592-4b3d-89e4-159749ad3c76"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e2684e59-d5bb-4c4f-bf40-f50af3f0deaf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c46aa33-7ecc-4fc6-a242-862aae3ffc6b"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Research"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""603212e0-d2ae-453e-ade1-9dea9d42a80f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot_Special"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMini
        m_PlayerMini = asset.FindActionMap("PlayerMini", throwIfNotFound: true);
        m_PlayerMini_Movement = m_PlayerMini.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMini_Shoot = m_PlayerMini.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerMini_Research = m_PlayerMini.FindAction("Research", throwIfNotFound: true);
        m_PlayerMini_Shoot_Special = m_PlayerMini.FindAction("Shoot_Special", throwIfNotFound: true);
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

    // PlayerMini
    private readonly InputActionMap m_PlayerMini;
    private IPlayerMiniActions m_PlayerMiniActionsCallbackInterface;
    private readonly InputAction m_PlayerMini_Movement;
    private readonly InputAction m_PlayerMini_Shoot;
    private readonly InputAction m_PlayerMini_Research;
    private readonly InputAction m_PlayerMini_Shoot_Special;
    public struct PlayerMiniActions
    {
        private @PlayerMini_Control m_Wrapper;
        public PlayerMiniActions(@PlayerMini_Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMini_Movement;
        public InputAction @Shoot => m_Wrapper.m_PlayerMini_Shoot;
        public InputAction @Research => m_Wrapper.m_PlayerMini_Research;
        public InputAction @Shoot_Special => m_Wrapper.m_PlayerMini_Shoot_Special;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMini; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMiniActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMiniActions instance)
        {
            if (m_Wrapper.m_PlayerMiniActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnMovement;
                @Shoot.started -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot;
                @Research.started -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnResearch;
                @Research.performed -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnResearch;
                @Research.canceled -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnResearch;
                @Shoot_Special.started -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot_Special;
                @Shoot_Special.performed -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot_Special;
                @Shoot_Special.canceled -= m_Wrapper.m_PlayerMiniActionsCallbackInterface.OnShoot_Special;
            }
            m_Wrapper.m_PlayerMiniActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Research.started += instance.OnResearch;
                @Research.performed += instance.OnResearch;
                @Research.canceled += instance.OnResearch;
                @Shoot_Special.started += instance.OnShoot_Special;
                @Shoot_Special.performed += instance.OnShoot_Special;
                @Shoot_Special.canceled += instance.OnShoot_Special;
            }
        }
    }
    public PlayerMiniActions @PlayerMini => new PlayerMiniActions(this);
    public interface IPlayerMiniActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnResearch(InputAction.CallbackContext context);
        void OnShoot_Special(InputAction.CallbackContext context);
    }
}
