using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace domino_effect.LevelButtons
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private TextMeshProUGUI _textBox = null;

        private void Awake() {
            _button = GetComponent<Button>();
        }
        
        public void SetOnClick(UnityAction call) {
            _button.onClick.AddListener(call);
        }

        public void SetText(string text) {
            _textBox.text = text;
        }
    }
}
