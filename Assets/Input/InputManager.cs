using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace domino_effect.Input
{
    public class InputManager : MonoBehaviour
    {
        private GameInputActions gameInputActions;

        public UnityEvent OnSpawn;
        public UnityEvent OnDelete;

        public static InputManager Instance;

        private void Awake()
        {
            Instance = this;

            gameInputActions = new GameInputActions();
            gameInputActions.GameControls.Spawn.performed += (context) => OnSpawn.Invoke();
            gameInputActions.GameControls.Delete.performed += (context) => OnDelete.Invoke();
        }

        public Vector2 GetMousePosition()
        {
            var mouse = Mouse.current;
            if (mouse == null) return Vector2.zero;

            return mouse.position.ReadValue();
        }

        private void OnEnable()
        {
            gameInputActions.Enable();
        }

        private void OnDisable()
        {
            gameInputActions.Disable();
        }
    }
}
