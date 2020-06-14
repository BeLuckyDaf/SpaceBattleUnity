using GameCore.ContainerComponentModel;
using GameCore.ContainerComponentModel.Installers;
using GameCore.ContainerComponentModel.Interfaces;

namespace Modules.SBCore.Boot
{
    /// <summary>
    /// entry point for app
    /// handles intial boot process
    /// </summary>
    public class SBBoot : AMonoInstaller
    {
        public override void Install(IContainer container)
        {
            // register general project components via containter.Bind<Type>(component)
            // those components will live and will be accesible via while project lifecycle
        }

        private void Start()
        {
            SceneManagement.SceneLoader.LoadScene(SceneManagement.Scenes.Login); // load login screen after boot
        }
    }
}
