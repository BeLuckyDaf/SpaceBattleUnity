using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.Commands.Interfaces
{
    public interface IContainerCommand : ICommand
    {
        void Link(IContainer baseContainer);
        void Execute(IContainer container);
    }
}