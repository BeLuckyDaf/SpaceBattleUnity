using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.Commands.CompositeCommand
{
    public abstract class ASOCompositeCommand : ScriptableObject, ICompositeCommand
    {
        protected IContainer _baseParent;
        protected IContainer _baseChild;
        
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