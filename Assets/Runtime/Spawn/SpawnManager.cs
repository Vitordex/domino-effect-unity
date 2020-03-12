using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace domino_effect.Runtime.Spawn
{
    public class SpawnManager : BaseMonoBehaviour
    {
        public GameObject SpawnPrefab;
        public int SpawnLimit;
        public Transform SpawnPoint;

        public List<GameObject> Spawns = new List<GameObject>();

        public IntEvent OnSpawn = new IntEvent();

        private void Awake()
        {
            if (SpawnPrefab == null) Debug.LogError($"[{name}][Spawner][Awake] Please define an object prefab to Spawn on click");
            if (SpawnPoint == null) SpawnPoint = Transform;
        }

        private GameObject SpawnObject()
        {
            return Instantiate(SpawnPrefab, SpawnPoint.position, Quaternion.identity);
        }

        public void Spawn()
        {
            if (Spawns.Count >= SpawnLimit) return;

            var spawned = SpawnObject();
            Spawns.Add(spawned);
            OnSpawn.Invoke(Spawns.Count);
        }

        public void DeleteSpawn(GameObject spawn)
        {
            Spawns.Remove(spawn);
            Destroy(spawn);
        }

        public void ClearSpawns()
        {
            foreach (var spawn in Spawns)
                Destroy(spawn);

            Spawns.Clear();
        }
    }

    [SerializeField]
    public class IntEvent : UnityEvent<int> { }
}