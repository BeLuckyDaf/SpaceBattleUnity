using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace Modules.SBGame.SessionLoad.UI
{
    /// <summary>
    /// ui for session loading slider
    /// </summary>
    public class SessionLoadProgress : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _currentStage;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private float _smoothingRate = 30;

        private float _currentProgress;
        private Coroutine _currentRoutine;

        private void Awake()
        {
            _currentProgress = 0;
            _progressSlider.value = 0.0f;
        }

        public void AsyncOp(AsyncOperation op, string message, float progressStart, float progressEnd) 
        {   
            if (_currentRoutine != null)
                StopCoroutine(_currentRoutine);

            _currentStage.text = message;

            StartCoroutine(OnAsyncOperation(op, progressStart, progressEnd));
        }

        private void Update()
        {
            _progressSlider.value = Mathf.Lerp(_progressSlider.value, _currentProgress, _smoothingRate * Time.deltaTime);
        }

        private IEnumerator OnAsyncOperation(AsyncOperation op, float progressStart, float progressEnd) 
        {
            while (!op.isDone) 
            {
                _currentProgress = progressStart + op.progress * (progressEnd - progressStart);
                yield return null;
            }
        }
    }
}
