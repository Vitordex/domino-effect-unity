using UnityEngine;

namespace domino_effect.PhysicsSimulation {
  public class GravitySimulation : MonoBehaviour, ISimulation {
    private Vector3 _initialGravity;

    private void Awake() {
      _initialGravity = Physics.gravity;
    }

    public void Start() {
      Physics.gravity = _initialGravity;
    }

    public void Stop() {
      Physics.gravity = Vector3.zero;
    }
  }
}
