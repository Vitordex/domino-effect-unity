using domino_effect;
using UnityEngine;

namespace domino_effect.PhysicsBody
{
    [RequireComponent(typeof(Rigidbody))]
    public class DominoBody : BaseMonoBehaviour, IBody
    {
        private Rigidbody _rigidbody;

        public Rigidbody RigidBody => _rigidbody;

        private (Vector3, Quaternion) _initialValues;
        public (Vector3, Quaternion) InitialValues => _initialValues;

        private Vector3 _forceApplyPosition;

        [SerializeField] private float _forceMultiplier = 17f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _forceApplyPosition = Transform.GetChild(0).transform.position;
        }

        private void Start()
        {
            _initialValues = (Transform.position, Transform.rotation);
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void Rollback()
        {
            Transform.position = _initialValues.Item1;
            Transform.rotation = _initialValues.Item2;

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }

        [ContextMenu("Apply Force")]
        public void ApplyForce()
        {
          _rigidbody.AddForceAtPosition(Vector3.right * _forceMultiplier, _forceApplyPosition, ForceMode.Acceleration);
        }
    }
}
