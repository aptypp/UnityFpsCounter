using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace AVP.FPSCounter
{
    public class FPSCounter : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TMP_Text _fpsText;
        [SerializeField] private TMP_Text _timeText;
        
        [Header("Settings")]
        [SerializeField] [Range(1.0f, 60.0f)] private float _frequency = 15.0f;

        private Coroutine _fpsCounterRoutine;

        private void OnEnable() => _fpsCounterRoutine = StartCoroutine(FpsCounterRoutine());

        private void OnDisable() => StopCoroutine(_fpsCounterRoutine);

        private void UpdateTexts()
        {
            _fpsText.text = $"FPS: {(int) (1.0f / Time.deltaTime)}";
            _timeText.text = $"MS: {Time.deltaTime * 1000.0f:F2}";
        }

        private IEnumerator FpsCounterRoutine()
        {
            while (true)
            {
                UpdateTexts();
                yield return new WaitForSecondsRealtime(1.0f / _frequency);
            }
        }
    }
}