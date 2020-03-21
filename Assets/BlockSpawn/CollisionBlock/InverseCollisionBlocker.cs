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
            InvokeEventOnValueChange(blocked, _isBlocked);
            _isBlocked = blocked;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsEnabled) return;

            var blocked = IsSpawnBlocked(shouldBlock: true, other.tag);
            InvokeEventOnValueChange(blocked, _isBlocked);
            _isBlocked = blocked;
        }

        private void InvokeEventOnValueChange(bool blocked, bool oldValue)
        {
            if (blocked == oldValue) return;

            InvokeEvent(blocked);
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

            InvokeEventIfEnabled(_isBlocked);
        }

        public void Block(bool block)
        {
            _isBlocked = block;

            InvokeEventIfEnabled(_isBlocked);
        }

        private void InvokeEventIfEnabled(bool blocked)
        {
            if (!_isEnabled) return;

            InvokeEvent(blocked);
        }

        private void InvokeEvent(bool blocked)
        {
            var invokeEvent = blocked ? OnBlock : OnUnblock;
            invokeEvent.Invoke();
        }
    }
}
