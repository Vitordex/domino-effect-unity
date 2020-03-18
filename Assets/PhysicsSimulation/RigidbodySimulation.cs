using UnityEngine;

namespace domino_effect.PhysicsSimulation {
  public class RigidbodySimulation : MonoBehaviour, ISimulation {
    public void Initiate() {
      var rigidbodies = FindObjectsOfType<Rigidbody>();
      foreach (var rigidbody in rigidbodies) {
        rigidbody.constraints = RigidbodyConstraints.None;
      }
    }

    public void Stop() {
      var rigidbodies = FindObjectsOfType<Rigidbody>();
      foreach (var rigidbody in rigidbodies) {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
      }
    }
  }
}
