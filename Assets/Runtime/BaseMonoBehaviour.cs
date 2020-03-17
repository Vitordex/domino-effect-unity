using UnityEngine;

namespace domino_effect {
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

    private Animator _animator;
    protected Animator Animator {
      get {
        if (_animator == null) {
          _animator = GetComponent<Animator>();
        }

        return _animator;
      }
    }
  }
}
