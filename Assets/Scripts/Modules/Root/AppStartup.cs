using GameCore.ContainerComponentModel.Installers;
using GameCore.ContainerComponentModel.Interfaces;
namespace Modules.Root 
{

    public class AppStartup : AMonoInstaller
    {
        public override void Install(IContainer container)
        {
            // register project dependencies via container.Bind<Type>(object);
        }

        /// <summary>
        /// call after all 3rd party services init
        /// </summary>
        private void LoadGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }


        void Start ()
        {
            LoadGame();
        }

        private void InitCallback ()
        {
            LoadGame();
        }
    }
}
