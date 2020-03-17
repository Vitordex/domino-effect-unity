using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace domino_effect.Runtime
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance;

        [SerializeField] private UnityEvent OnEndLevel;
        [SerializeField] private UnityEvent OnStartLevel;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        public void StartLevel()
        {
            OnStartLevel.Invoke();
        }

        public void EndGame()
        {
            OnEndLevel.Invoke();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}