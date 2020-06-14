using GameCore.ContainerComponentModel;
using GameCore.ContainerComponentModel.Containers;
using UnityEngine;

namespace Modules.SBGame.SessionLoad
{
    /// <summary>
    /// entry point for session load stage
    /// </summary>
    public class SessionLoader : MonoBehaviour
    {
        private UI.SessionLoadProgress _progressBar;

        private void Awake()
        {
            // in that case its ok
            _progressBar = FindObjectOfType<UI.SessionLoadProgress>();
        }

        private void Start()
        {
            SceneContainer.Instance.Inject(this);

            StartLoad();
        }

        public void LoadStagePassed() 
        {
        }

        /// <summary>
        /// starts general load of all required data for game session
        /// </summary>
        private void StartLoad()
        {
            OnLoadingComplete();
        }

        /// <summary>
        /// starts loading of a regular session scene
        /// </summary>
        private void OnLoadingComplete()
        {
            var op = SBCore.SceneManagement.SceneLoader.LoadSceneAsync(SBCore.SceneManagement.Scenes.RegularSession);
            if(_progressBar != null) 
            {
                _progressBar.AsyncOp(op, "loading scene", 0.0f, 1.0f);
            }
        }
        
    }

}