using UnityEngine;
using UnityEngine.SceneManagement;

namespace domino_effect {
  public class GameManager : MonoBehaviour {
    public GameObject MainMenuInterface;

    private void Awake() {
      DontDestroyOnLoad(this);
    }

    public void PlayGame() {
      SceneManager.LoadSceneAsync(1);
      MainMenuInterface.SetActive(false);
    }

    public void ExitGame() {
      Application.Quit();
    }
  }
}
