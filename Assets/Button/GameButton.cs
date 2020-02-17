using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace domino_effect.Runtime {
  public class GameButton : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
      LevelManager.Instance.EndGame();
    }
  }
}
