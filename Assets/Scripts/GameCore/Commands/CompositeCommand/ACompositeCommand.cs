using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.Commands.CompositeCommand
{
    public abstract class ACompositeCommand : ICompositeCommand
    {
        private IContainer _baseParent;
        private IContainer _baseChild;
        
        public void Link(IContainer baseParent, IContainer baseChild)
        {
            _baseParent = baseParent;
            _baseChild = baseChild;
        }
        
        public void Execute()
        {
            Execute(_baseParent, _baseChild);
        }

        public abstract void Execute(IContainer parent, IContainer child);
    }
}