using UnityEngine;
using UnityEngine.EventSystems;

namespace domino_effect.BlockSpawn {
  public class UIBlocker : MonoBehaviour, IBlocker, IPointerEnterHandler, IPointerExitHandler {
    private bool _isBlocked;
    public bool IsBlocked => _isBlocked;

    public void OnPointerEnter(PointerEventData eventData) {
      _isBlocked = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
      _isBlocked = false;
    }
  }
}
