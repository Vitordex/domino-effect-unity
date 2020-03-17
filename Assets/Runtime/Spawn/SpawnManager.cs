using System.Collections.Generic;
using domino_effect.PhysicsBody;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.Spawn {
  public class SpawnManager : BaseMonoBehaviour {
    public GameObject SpawnPrefab;
    public int SpawnLimit;
    public Transform SpawnPoint;

    public List<IBody> Spawns = new List<IBody>();

    public IntEvent OnSpawn = new IntEvent();

    private void Awake() {
      if (SpawnPrefab == null) Debug.LogError($"[{name}][Spawner][Awake] Please define an object prefab to Spawn on click");
      if (SpawnPoint == null) SpawnPoint = Transform;
    }

    private GameObject SpawnObject() {
      return Instantiate(SpawnPrefab, SpawnPoint.position, Quaternion.identity);
    }

    public void Spawn() {
      if (Spawns.Count >= SpawnLimit) return;

      var spawned = SpawnObject();
      Spawns.Add(spawned.GetComponent<IBody>());
      OnSpawn.Invoke(Spawns.Count);
    }

    public void DeleteSpawn(GameObject spawn) {
      Spawns.Remove(spawn?.GetComponent<IBody>());
      Destroy(spawn);
    }

    public void ClearSpawns() {
      foreach (var spawn in Spawns)
        Destroy(spawn.gameObject);

      Spawns.Clear();
      OnSpawn.Invoke(Spawns.Count);
    }

    public void RollbackSpawnsValues() {
      foreach (var spawn in Spawns)
        spawn.Rollback();
    }
  }

  [SerializeField]
  public class IntEvent : UnityEvent<int> { }
}