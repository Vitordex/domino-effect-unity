using UnityEngine;

namespace domino_effect.PhysicsSimulation {
    public class PhysicsUIController : MonoBehaviour {
        public bool IsEnabled = true;

        public GameObject StartSimButton;
        public GameObject StopSimButton;
        public GameObject ClearSimButton;

        private void Start() {
            if(IsEnabled) Enable();
            else Disable();
        }

        public void Disable() {
            SetObjectActive(StartSimButton, false);
            SetObjectActive(StopSimButton, false);
            SetObjectActive(ClearSimButton, false);
        }

        public void Enable() {
            SetObjectActive(StartSimButton, true);
            SetObjectActive(StopSimButton, true);
            SetObjectActive(ClearSimButton, true);
        }

        private void SetObjectActive(GameObject obj, bool active) {
            obj.SetActive(active);
        }
    }
}