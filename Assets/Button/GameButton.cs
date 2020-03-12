using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace domino_effect.Runtime
{
    public class GameButton : BaseMonoBehaviour
    {
        private GameButtonAnimatorController _controller;

        private void Awake()
        {
            _controller = GetComponentInChildren<GameButtonAnimatorController>();
        }

        private void OnCollisionEnter(Collision other)
        {
            _controller.Press();
            LevelManager.Instance.EndGame();
            GetComponent<Collider>().enabled = false;
        }
    }
}
