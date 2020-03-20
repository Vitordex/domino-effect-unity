using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace domino_effect.BlockSpawn
{
    public class UIBlocker : MonoBehaviour, IBlocker, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _isBlocked;
        public bool IsBlocked => _isBlocked;

        [SerializeField] private UnityEvent _onBlock = null;
        public UnityEvent OnBlock => _onBlock;

        [SerializeField] private UnityEvent _onUnblock = null;
        public UnityEvent OnUnblock => _onUnblock;

        [SerializeField] private bool _isEnabled = true;
        public bool IsEnabled => _isEnabled;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!IsEnabled) return;

            _isBlocked = true;
            OnBlock.Invoke();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsEnabled) return;

            _isBlocked = false;
            OnUnblock.Invoke();
        }

        public void SetEnabled(bool value)
        {
            _isEnabled = value;
        }
    }
}
