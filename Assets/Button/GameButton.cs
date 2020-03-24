using UnityEngine;
using UnityEngine.Events;

namespace domino_effect
{
    public class GameButton : BaseMonoBehaviour {
    private GameButtonAnimatorController _controller;
    public UnityEvent OnPress;

    private void Awake() {
      _controller = GetComponentInChildren<GameButtonAnimatorController>();
    }

    private void OnCollisionEnter(Collision other) {
      _controller.Press();
      LevelManager.Instance.EndGame();
      OnPress.Invoke();
    }
  }
}
