using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace domino_effect.LevelButtons
{
    public class LevelSelectManager : MonoBehaviour
    {
        public LevelButton ButtonPrefab;
        public Transform SelectionHolder;

        private void Awake() {
            var scenesCount = SceneManager.sceneCountInBuildSettings;
            var levelCount = 0;
            for (int i = 0; i < scenesCount; i++)
            {
                var scene = SceneUtility.GetScenePathByBuildIndex(i);
                if(!Regex.IsMatch(scene, "Level_\\d{2}")) continue;

                var buttonObject = Instantiate(ButtonPrefab, SelectionHolder);
                var button = buttonObject.GetComponent<LevelButton>();
                button.SetOnClick(() => SceneManager.LoadSceneAsync(scene));
                button.SetText($"{++levelCount:00}");
            }
        }
    }
}
