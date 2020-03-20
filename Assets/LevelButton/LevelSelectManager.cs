using System;
using System.Text.RegularExpressions;
using domino_effect.Transitions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace domino_effect.LevelButtons
{
    public class LevelSelectManager : MonoBehaviour
    {
        public LevelButton ButtonPrefab;
        public Transform SelectionHolder;

        private void Awake()
        {
            var scenesCount = SceneManager.sceneCountInBuildSettings;
            var levelCount = 0;
            for (int i = 0; i < scenesCount; i++)
            {
                var scene = SceneUtility.GetScenePathByBuildIndex(i);
                if (!Regex.IsMatch(scene, "Level_\\d{2}")) continue;

                var buttonObject = Instantiate(ButtonPrefab, SelectionHolder);
                var button = buttonObject.GetComponent<LevelButton>();
                levelCount = ConfigureButton(button, scene, levelCount);
            }
        }

        private int ConfigureButton(LevelButton button, string scene, int levelCount)
        {
            Action loadScene = () => SceneManager.LoadSceneAsync(scene);

            var fadeIn = true;
            UnityAction fadeExecute = () => FadeManager.Instance.FadeExecute(loadScene, fadeIn);

            button.SetOnClick(fadeExecute);
            button.SetText($"{++levelCount:00}");

            return levelCount;
        }
    }
}
