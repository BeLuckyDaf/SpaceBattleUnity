using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.ContainerComponentModel.Installers
{
    /// <summary>
    /// abstract realisation of MonoInstaller
    /// used to wrap installer into MonoBehaviour
    /// </summary>
    public abstract class AMonoInstaller : MonoBehaviour, IInstaller
    {
        public abstract void Install(IContainer container);
    }
}