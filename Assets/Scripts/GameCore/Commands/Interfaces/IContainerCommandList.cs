using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.Commands.Interfaces
{
    public interface IContainerCommandList : IContainerCommand
    {
        void Inject(IContainerCommand command);
        void Remove(IContainerCommand command);
        void Execute(IContainer container);
    }
}