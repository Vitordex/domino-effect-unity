using System;
using UnityEngine;

namespace domino_effect.PhysicsSimulation {
  public class TimeSimulation : MonoBehaviour, ISimulation {
    public void Initiate() {
      Time.timeScale = 1f;
    }

    public void Stop() {
      Time.timeScale = 0f;
    }
  }
}
