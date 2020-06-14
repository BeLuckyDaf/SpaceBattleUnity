using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.Commands.Interfaces
{
    public interface ICompositeCommand : ICommand
    {
        void Link(IContainer baseParent, IContainer baseChild);
        void Execute(IContainer parent, IContainer child);
    }
}