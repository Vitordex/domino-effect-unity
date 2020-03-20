using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace domino_effect {
  public class LevelManager : MonoBehaviour {
    public static LevelManager Instance;

    [SerializeField] private UnityEvent OnStartLevel = null;
    [SerializeField] private UnityEvent OnEndLevel = null;

    private void Awake() {
      Instance = this;
      DontDestroyOnLoad(this);
    }

    public void StartLevel() {
      OnStartLevel.Invoke();
    }

    public void EndGame() {
      OnEndLevel.Invoke();
    }

    public void GoToMainMenu() {
      SceneManager.LoadSceneAsync(0);
    }

    public void RestartLevel() {
      SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
  }
}