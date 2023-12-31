﻿using System.Collections.Generic;
using System.Linq;
using domino_effect.PhysicsBody;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.Spawn {
  [RequireComponent(typeof(SpawnBlocker))]
  public class SpawnManager : BaseMonoBehaviour {
    public GameObject SpawnPrefab;
    public int SpawnLimit;
    public Transform SpawnPoint;

    private SpawnBlocker _spawnBlocker;

    public List<IBody> Spawns = new List<IBody>();

    public IntEvent OnSpawn = new IntEvent();
    public UnityEvent OnFirstSpawn;

    public UnityEvent OnEmptyArray;

    private void Awake() {
      if (SpawnPrefab == null) Debug.LogError($"[{name}][Spawner][Awake] Please define an object prefab to Spawn on click");
      if (SpawnPoint == null) SpawnPoint = Transform;

      _spawnBlocker = GetComponent<SpawnBlocker>();
    }

    private GameObject SpawnObject() {
      return Instantiate(SpawnPrefab, SpawnPoint.position, Quaternion.identity);
    }

    public void Spawn() {
      if (Spawns.Count >= SpawnLimit) return;

      if (_spawnBlocker.IsSpawnBlocked()) return;

      var spawned = SpawnObject();
      Spawns.Add(spawned.GetComponent<IBody>());
      
      if(Spawns.Count == 1) OnFirstSpawn.Invoke();
      
      OnSpawn.Invoke(Spawns.Count);
    }

    public void DeleteSpawn(GameObject spawn) {
      Spawns.Remove(spawn?.GetComponent<IBody>());
      Destroy(spawn);

      if(Spawns.Count <= 0) OnEmptyArray.Invoke();
      
      OnSpawn.Invoke(Spawns.Count);
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

    public void ApplyForceToFirstDomino() {
      var firstSpawn = Spawns.FirstOrDefault();
      firstSpawn?.ApplyForce();
    }
  }

  [SerializeField]
  public class IntEvent : UnityEvent<int> { }
}