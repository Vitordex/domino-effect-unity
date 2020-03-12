using domino_effect.Runtime.Spawn;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.PhysicsSimulation
{
    public class SimulationController : MonoBehaviour
    {
        private List<(Vector3, Quaternion)> _simulationStartMap = new List<(Vector3, Quaternion)>();

        public UnityEvent OnStart;
        public UnityEvent OnStop;
        public UnityEvent OnClear;

        private TimeController _timeController;
        private SpawnManager _spawnManager;

        private void Awake()
        {
            _spawnManager = FindObjectOfType<SpawnManager>();

            _timeController = GetComponentInChildren<TimeController>();
            _timeController.StopTime();
        }

        public void StartSimulation()
        {
            _timeController.StartTime();

            var rawSpawns = _spawnManager.Spawns;
            _simulationStartMap = rawSpawns.Select((spawn) => (spawn.transform.position, spawn.transform.rotation)).ToList();

            OnStart.Invoke();
        }

        public void StopSimulation()
        {
            _timeController.StopTime();

            var spawns = _spawnManager.Spawns;
            for (int i = 0; i < spawns.Count; i++)
            {
                var spawn = spawns[i];
                var initialTransform = _simulationStartMap[i];
                spawn.transform.position = initialTransform.Item1;
                spawn.transform.rotation = initialTransform.Item2;
            }

            _simulationStartMap.Clear();

            OnStop.Invoke();
        }

        public void ClearSimulation()
        {
            _timeController.StopTime();
            _spawnManager.ClearSpawns();
            _simulationStartMap.Clear();

            OnClear.Invoke();
        }
    }
}
