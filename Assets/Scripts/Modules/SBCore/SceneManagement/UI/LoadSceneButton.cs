using UnityEngine;
using UnityEngine.UI;

namespace Modules.SBCore.SceneManagement.UI
{
    /// <summary>
    /// generally for dev purposes
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class LoadSceneButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Scenes _sceneToLoad;

        public void Awake() 
        {
            _button.onClick.AddListener(Do);
        }

        public void Do() 
        {
            SceneLoader.LoadScene(_sceneToLoad);
        }

#if UNITY_EDITOR

        private void Reset() 
        {
            _button = GetComponent<Button>();
        }

#endif
    }
}
