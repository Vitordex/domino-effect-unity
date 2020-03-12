// GENERATED AUTOMATICALLY FROM 'Assets/Input/GameInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameInputActions"",
    ""maps"": [
        {
            ""name"": ""GameControls"",
            ""id"": ""7a331d82-37a7-43af-83d9-71773a2dae5f"",
            ""actions"": [
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Button"",
                    ""id"": ""afa73ba8-582b-42db-9f5f-131319d9b792"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Delete"",
                    ""type"": ""Button"",
                    ""id"": ""4a626b0d-ba68-4cf0-a68e-e36b1f6ecaa9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BackToMenu"",
                    ""type"": ""Button"",
                    ""id"": ""eff17430-cbac-4839-938d-2a8f10ba225f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""868cb470-0fda-460e-9377-297b33642853"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""870b1223-184d-42f6-8f0c-39850dc5fd05"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96c34bfa-8456-4643-892b-fe756083ab70"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BackToMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameControls
        m_GameControls = asset.FindActionMap("GameControls", throwIfNotFound: true);
        m_GameControls_Spawn = m_GameControls.FindAction("Spawn", throwIfNotFound: true);
        m_GameControls_Delete = m_GameControls.FindAction("Delete", throwIfNotFound: true);
        m_GameControls_BackToMenu = m_GameControls.FindAction("BackToMenu", throwIfNotFound: true);
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

    // GameControls
    private readonly InputActionMap m_GameControls;
    private IGameControlsActions m_GameControlsActionsCallbackInterface;
    private readonly InputAction m_GameControls_Spawn;
    private readonly InputAction m_GameControls_Delete;
    private readonly InputAction m_GameControls_BackToMenu;
    public struct GameControlsActions
    {
        private @GameInputActions m_Wrapper;
        public GameControlsActions(@GameInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Spawn => m_Wrapper.m_GameControls_Spawn;
        public InputAction @Delete => m_Wrapper.m_GameControls_Delete;
        public InputAction @BackToMenu => m_Wrapper.m_GameControls_BackToMenu;
        public InputActionMap Get() { return m_Wrapper.m_GameControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameControlsActions set) { return set.Get(); }
        public void SetCallbacks(IGameControlsActions instance)
        {
            if (m_Wrapper.m_GameControlsActionsCallbackInterface != null)
            {
                @Spawn.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpawn;
                @Spawn.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpawn;
                @Spawn.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnSpawn;
                @Delete.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnDelete;
                @Delete.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnDelete;
                @Delete.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnDelete;
                @BackToMenu.started -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnBackToMenu;
                @BackToMenu.performed -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnBackToMenu;
                @BackToMenu.canceled -= m_Wrapper.m_GameControlsActionsCallbackInterface.OnBackToMenu;
            }
            m_Wrapper.m_GameControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Spawn.started += instance.OnSpawn;
                @Spawn.performed += instance.OnSpawn;
                @Spawn.canceled += instance.OnSpawn;
                @Delete.started += instance.OnDelete;
                @Delete.performed += instance.OnDelete;
                @Delete.canceled += instance.OnDelete;
                @BackToMenu.started += instance.OnBackToMenu;
                @BackToMenu.performed += instance.OnBackToMenu;
                @BackToMenu.canceled += instance.OnBackToMenu;
            }
        }
    }
    public GameControlsActions @GameControls => new GameControlsActions(this);
    public interface IGameControlsActions
    {
        void OnSpawn(InputAction.CallbackContext context);
        void OnDelete(InputAction.CallbackContext context);
        void OnBackToMenu(InputAction.CallbackContext context);
    }
}
