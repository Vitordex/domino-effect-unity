using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.Actions {
    public class Action : MonoBehaviour {
        public UnityEvent OnTrigger;

        public virtual void Trigger() {
            OnTrigger.Invoke();
        }
    }
}