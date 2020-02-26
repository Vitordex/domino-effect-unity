using UnityEngine;

namespace domino_effect.Runtime {
  public class BaseMonoBehaviour : MonoBehaviour {
    private Transform _cachedTransform;
    protected Transform Transform {
      get {
        if (_cachedTransform == null) {
          _cachedTransform = transform;
        }

        return _cachedTransform;
      }
    }

    private Camera _mainCamera;
    protected Camera MainCamera {
      get {
        if (_mainCamera == null) {
          _mainCamera = Camera.main;
        }

        return _mainCamera;
      }
    }
  }
}
