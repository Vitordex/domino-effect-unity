using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace domino_effect.PhysicsSimulation
{
    public class TimeController : MonoBehaviour
    {
        public void StartTime()
        {
            Time.timeScale = 1f;
        }

        public void StopTime()
        {
            Time.timeScale = 0f;
        }
    }
}
