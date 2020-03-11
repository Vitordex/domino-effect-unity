using TMPro;
using UnityEngine;

namespace domino_effect.Runtime.Spawn {
  public class SpawnUIBinder : MonoBehaviour {
    public TextMeshProUGUI _uiText;
    private SpawnManager _manager;

    private void Awake() {
      _manager = FindObjectOfType<SpawnManager>();
      _manager.OnSpawn.AddListener(UpdateText);

      UpdateText(0);
    }

    public void UpdateText(int count) {
      var padCount = ConvertToTwoDigitString(count);
      var padLimit = ConvertToTwoDigitString(_manager.SpawnLimit);
      _uiText.text = $"{padCount}|{padLimit}";
    }

    private string ConvertToTwoDigitString(int number) {
      return number.ToString().PadLeft(2, '0');
    }
  }
}