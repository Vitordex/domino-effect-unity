using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using domino_effect.Transitions;
using System;

namespace domino_effect
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [SerializeField] private UnityEvent OnStartLevel = null;
        [SerializeField] private UnityEvent OnEndLevel = null;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            FadeManager.Instance.SimpleFade(false);
        }

        public void StartLevel()
        {
            OnStartLevel.Invoke();
        }

        public void EndGame()
        {
            OnEndLevel.Invoke();
            FadeManager.Instance.FadeExecute(() => LoadNextLevel(), true, 3f);
        }

        public void GoToMainMenu()
        {
            Action loadMenu = () => SceneManager.LoadSceneAsync(0);
            FadeManager.Instance.FadeExecute(loadMenu, true);
        }

        public void RestartLevel()
        {
            Action reloadScene = () => SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            FadeManager.Instance.FadeExecute(reloadScene, true);
        }

        private void LoadNextLevel()
        {
            var index = SceneManager.GetActiveScene().buildIndex;
            if(index + 1 == SceneManager.sceneCountInBuildSettings) index = -1;
            SceneManager.LoadSceneAsync(index + 1);
        }
    }
}