using domino_effect.Input;
using domino_effect.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace domino_effect.Runtime.Spawn
{
    public class SpawnDeleter : BaseMonoBehaviour
    {
        public LayerMask SpawnLayers;

        private SpawnManager _spawnManager;

        private void Awake()
        {
            _spawnManager = GetComponent<SpawnManager>();
        }

        public void Delete()
        {
            var mousePosition = InputManager.Instance.GetMousePosition();
            var ray = MainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, SpawnLayers))
                _spawnManager.DeleteSpawn(hit.collider.gameObject);
        }
    }
}
