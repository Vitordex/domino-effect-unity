using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace domino_effect.Runtime {
  public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    [SerializeField] private UnityEvent OnEndLevel;

    private void Awake() {
      Instance = this;
    }

    public void EndGame() {
      OnEndLevel.Invoke();
    }

    public void RestartLevel() {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}