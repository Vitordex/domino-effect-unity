using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
  public TextMeshProUGUI ButtonText;

  public AudioMixer audioMixer;
  public bool Muted;

  public void ToggleAudio() {
    audioMixer.SetFloat("Volume", Muted ? -80f : -10f);
    Muted = !Muted;
    ButtonText.text = MuteText;
  }

  public string MuteText {
    get => Muted ? "Unmute" : "Mute";
  }
}
