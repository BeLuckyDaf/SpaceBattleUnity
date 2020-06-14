using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.Commands.ContainerCommand
{
    public abstract class AContainerCommand : IContainerCommand
    {
        private IContainer _baseContainer;
        
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