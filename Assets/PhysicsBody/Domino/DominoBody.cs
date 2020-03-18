using domino_effect;
using UnityEngine;

namespace domino_effect.PhysicsBody {
  [RequireComponent(typeof(Rigidbody))]
  public class DominoBody : BaseMonoBehaviour, IBody {
    private Rigidbody _rigidbody;

    public Rigidbody RigidBody => _rigidbody;

    private (Vector3, Quaternion) _initialValues;
    public (Vector3, Quaternion) InitialValues => _initialValues;

    private void Awake() {
      _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() {
      _initialValues = (Transform.position, Transform.rotation);
      _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    public void Rollback() {
      Transform.position = _initialValues.Item1;
      Transform.rotation = _initialValues.Item2;

      _rigidbody.velocity = Vector3.zero;
      _rigidbody.angularVelocity = Vector3.zero;
    }
  }
}
