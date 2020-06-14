using System.Collections.Generic;
using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.Commands.CompositeCommand
{
    [System.Serializable]
    public class CompositeCommandList : ACompositeCommand, ICompositeCommandList
    {
        [SerializeField] protected List<ASOCompositeCommand> _soCommands = new List<ASOCompositeCommand>();
        protected List<ICompositeCommand> _commands = new List<ICompositeCommand>();

        public override void Execute(IContainer parent, IContainer child)
        {
            _commands.ForEach(command => command.Execute(parent, child));
            _soCommands.ForEach(commnad => commnad.Execute(parent,child));
        }

        public void Inject(ICompositeCommand command)
        {
            _commands.Add(command);
        }
        
        public void Remove(ICompositeCommand command)
        {
            _commands.Remove(command);
        }
    }
}