using System.Collections;
using UnityEngine;
using TMPro;

namespace AVP.FPSCounter
{
    public class FrameCounter : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private TMP_Text _fpsText;
        [SerializeField] private TMP_Text _timeText;
        
        [Header("Settings")]
        [SerializeField] [Range(1.0f, 60.0f)] private float _frequency = 15.0f;
        
        private Coroutine _counterRoutine;

        private void OnEnable() => _counterRoutine = StartCoroutine(FpsCounterRoutine());

        private void OnDisable() => StopCoroutine(_counterRoutine);

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