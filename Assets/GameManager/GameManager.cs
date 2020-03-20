using domino_effect.Transitions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace domino_effect
{
    public class GameManager : MonoBehaviour
    {
        public GameObject MainMenuInterface;
        public UnityEvent OnGameStart;

        private void Start()
        {
            FadeManager.Instance.SimpleFade(false);
            OnGameStart.Invoke();
        }

        public void PlayGame()
        {
            SceneManager.LoadSceneAsync(1);
            MainMenuInterface.SetActive(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
