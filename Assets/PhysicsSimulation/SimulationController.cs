using domino_effect.Spawn;
using UnityEngine;

namespace domino_effect.PhysicsSimulation {
  public class SimulationController : MonoBehaviour {
    private ISimulation _simulation;
    private SpawnManager _spawnManager;

    private void Awake() {
      _spawnManager = FindObjectOfType<SpawnManager>();
      _simulation = GetComponentInChildren<ISimulation>();
    }

    private void Start() {
      _simulation.Stop();
    }

    public void StartSimulation() {
      _simulation.Initiate();
    }

    public void StopSimulation() {
      _simulation.Stop();
      _spawnManager.RollbackSpawnsValues();
    }

    public void ClearSimulation() {
      _simulation.Stop();
      _spawnManager.ClearSpawns();
    }
  }
}
