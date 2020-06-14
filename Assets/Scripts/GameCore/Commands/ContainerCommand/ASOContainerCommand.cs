using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.Commands.ContainerCommand
{
    public abstract class ASOContainerCommand : ScriptableObject, IContainerCommand
    {
        protected IContainer _baseContainer;
        
        public void Execute()
        {
            Execute(_baseContainer);
        }

        public void Link(IContainer baseContainer)
        {
            _baseContainer = baseContainer;
        }

        public abstract void Execute(IContainer container);
    }
}