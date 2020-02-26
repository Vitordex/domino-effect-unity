using UnityEngine;

namespace domino_effect.Runtime {
  public class Spawner : BaseMonoBehaviour {
    public GameObject Spawn;

    public Transform SpawnPoint;

    private void Awake() {
      if (Spawn == null) Debug.LogError($"[{name}][Spawner][Awake] Please define an object prefab to Spawn on click");
      if (SpawnPoint == null) SpawnPoint = Transform;
    }

    private void Update() {
      if (Spawn == null) return;

      if (Input.GetMouseButtonDown(0)) {
        GameObject.Instantiate(Spawn, SpawnPoint.position, Quaternion.identity);
      }
    }
  }
}
