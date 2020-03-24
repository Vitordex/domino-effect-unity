using domino_effect.Transitions;
using UnityEngine.SceneManagement;

namespace domino_effect.Actions
{
    public class PlayGameAction : Action
    {
        public override void Trigger() {
            System.Action loadScene = () => SceneManager.LoadSceneAsync(1);

            var fadeIn = true;
            FadeManager.Instance.FadeExecute(loadScene, fadeIn);

            base.Trigger();
        }
    }
}
