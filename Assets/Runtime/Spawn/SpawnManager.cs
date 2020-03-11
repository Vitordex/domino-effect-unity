using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.Runtime.Spawn {
  public class SpawnManager : BaseMonoBehaviour {
    public GameObject Spawn;
    public int SpawnLimit;
    public Transform SpawnPoint;

    private List<GameObject> _spawns = new List<GameObject>();

    public IntEvent OnSpawn = new IntEvent();

    private void Awake() {
      if (Spawn == null) Debug.LogError($"[{name}][Spawner][Awake] Please define an object prefab to Spawn on click");
      if (SpawnPoint == null) SpawnPoint = Transform;
    }

    private void Update() {
      if (Spawn == null) return;

      var mouseDown = Input.GetMouseButtonDown(0);
      if (_spawns.Count < SpawnLimit && mouseDown) {
        var spawned = SpawnObject();
        _spawns.Add(spawned);
        OnSpawn.Invoke(_spawns.Count);
      }
    }

    private GameObject SpawnObject() {
      return GameObject.Instantiate(Spawn, SpawnPoint.position, Quaternion.identity);
    }
  }

  [SerializeField]
  public class IntEvent : UnityEvent<int> { }
}