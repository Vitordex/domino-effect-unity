using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace domino_effect.Transitions
{
    public class FadeManager : MonoBehaviour
    {
        public static FadeManager Instance;

        public UnityEvent OnFadeIn;
        public UnityEvent OnFadeOut;

        public float FadeStep = 2;

        private Image fadePanel;
        private float targetAlpha = 0f;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(this.gameObject); return; }

            Instance = this;

            DontDestroyOnLoad(this);
            fadePanel = GetComponentInChildren<Image>();
        }

        private void Update()
        {
            if (fadePanel.color.a != targetAlpha)
            {
                var color = fadePanel.color;
                color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * FadeStep);
                fadePanel.color = color;
            }
        }

        public void SimpleFade(bool fadeIn)
        {
            StartCoroutine(FadeAsync(() => { }, fadeIn, 0f));
        }

        public void FadeExecute(Action action, bool fadeIn = true, float waitTime = 0f)
        {
            StartCoroutine(FadeAsync(action, fadeIn, waitTime));
        }

        private IEnumerator FadeAsync(Action action, bool fadeIn, float waitTime)
        {
            fadePanel.raycastTarget = true;
            yield return new WaitForSeconds(waitTime);
            yield return Fade(fadeIn ? 1 : 0);
            action();
            fadePanel.raycastTarget = false;
        }

        public IEnumerator Fade(float finalValue)
        {
            targetAlpha = finalValue;
            while (!fadePanel.color.a.IsClose(finalValue, 0.01f))
            {
                yield return null;
            }

            if (finalValue == 1) OnFadeIn?.Invoke();
            else if (finalValue == 0) OnFadeOut?.Invoke();
        }
    }

    public static class FloatExtensions
    {
        public static bool IsClose(this float current, float to, float tolerance = float.Epsilon)
        {
            return System.Math.Abs(current - to) < tolerance;
        }
    }
}