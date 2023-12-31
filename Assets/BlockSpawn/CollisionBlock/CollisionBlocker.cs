using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.BlockSpawn
{
    public class CollisionBlocker : MonoBehaviour, IBlocker
    {
        private bool _isBlocked = false;

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

            _isBlocked = IsPlayerObject(other.tag) ? true : _isBlocked;
            if (_isBlocked) OnBlock.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!IsEnabled) return;

            _isBlocked = IsPlayerObject(other.tag) ? false : _isBlocked;
            if (!_isBlocked) OnUnblock.Invoke();
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
