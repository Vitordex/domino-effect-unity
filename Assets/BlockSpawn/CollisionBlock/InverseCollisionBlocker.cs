using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.BlockSpawn
{
    public class InverseCollisionBlocker : MonoBehaviour, IBlocker
    {
        [SerializeField] private bool _isBlocked = false;

        public bool IsBlocked => _isBlocked;

        [SerializeField] private UnityEvent _onBlock = null;
        public UnityEvent OnBlock => _onBlock;

        [SerializeField] private UnityEvent _onUnblock = null;
        public UnityEvent OnUnblock => _onUnblock;

        [SerializeField] private bool _isEnabled = true;
        public bool IsEnabled => _isEnabled;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsEnabled) return;

            var blocked = IsSpawnBlocked(shouldBlock: false, other.tag);
            InvokeEvent(blocked, _isBlocked);
            _isBlocked = blocked;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsEnabled) return;

            var blocked = IsSpawnBlocked(shouldBlock: true, other.tag);
            InvokeEvent(blocked, _isBlocked);
            _isBlocked = blocked;
        }

        private void InvokeEvent(bool blocked, bool oldValue)
        {
            if (blocked == oldValue) return;

            var invokeEvent = blocked ? OnBlock : OnUnblock;
            invokeEvent.Invoke();
        }

        private bool IsSpawnBlocked(bool shouldBlock, string tag)
        {
            return IsPlayerObject(tag) ? shouldBlock : _isBlocked;
        }

        private bool IsPlayerObject(string tag)
        {
            return tag == Tags.Player;
        }

        public void SetEnabled(bool value)
        {
            _isEnabled = value;
        }
    }
}
