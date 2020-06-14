using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.ContainerComponentModel.Installers
{
    /// <summary>
    /// abstract realisation for SO installers
    /// used to wrap installer into SO
    /// </summary>
    public abstract class ASOInstaller : ScriptableObject, IInstaller
    {
        public abstract void Install(IContainer container);
    }
}