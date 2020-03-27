using domino_effect.Input;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.BlockSpawn {
    public class ObjectBlocker : BaseMonoBehaviour, IBlocker
    {
        private bool _isBlocked = false;

        public bool IsBlocked => _isBlocked;

        [SerializeField] private UnityEvent _onBlock = null;
        public UnityEvent OnBlock => _onBlock;

        [SerializeField] private UnityEvent _onUnblock = null;

        public UnityEvent OnUnblock => _onUnblock;

        [SerializeField] private bool _isEnabled = true;
        public bool IsEnabled => _isEnabled;

        public float MaxRayDistance = 200f;
        public LayerMask SearchMask;

        private void Update() {
            if(!_isEnabled) return;

            var ray = MainCamera.ScreenPointToRay(InputManager.Instance.GetMousePosition());
            var oldValue = _isBlocked;
            _isBlocked = Physics.Raycast(ray, MaxRayDistance, SearchMask);

            if(_isBlocked != oldValue) {
                if(_isBlocked) OnBlock.Invoke();
                else OnUnblock.Invoke();
            }
        }

        public void SetEnabled(bool value)
        {
            _isEnabled = value;   
        }
    }
}