using domino_effect.Input;
using domino_effect;
using UnityEngine;

namespace domino_effect.Spawn {
  public class SpawnDeleter : BaseMonoBehaviour {
    public LayerMask SpawnLayers;

    private SpawnManager _spawnManager;

    private void Awake() {
      _spawnManager = GetComponent<SpawnManager>();
    }

    public void Delete() {
      var mousePosition = InputManager.Instance.GetMousePosition();
      var ray = MainCamera.ScreenPointToRay(mousePosition);
      RaycastHit hitInfo;
      var hitSomething = Physics.Raycast(ray, out hitInfo, 1000f, SpawnLayers);
      if (hitSomething) _spawnManager.DeleteSpawn(hitInfo.collider.gameObject);
    }
  }
}
