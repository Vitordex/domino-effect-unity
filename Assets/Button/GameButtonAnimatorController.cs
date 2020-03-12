using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace domino_effect.Runtime
{
    public class GameButtonAnimatorController : MonoBehaviour
    {
        public string TriggerName = "Pressed";

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Press()
        {
            _animator.SetTrigger(TriggerName);
        }
    }
}
