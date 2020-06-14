using System.Collections.Generic;
using GameCore.Commands.Interfaces;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.Commands.ContainerCommand
{
    [System.Serializable]
    public class ContainerCommandList : AContainerCommand, IContainerCommandList
    {
        [SerializeField] protected List<ASOContainerCommand> _soCommands = new List<ASOContainerCommand>();
        protected List<IContainerCommand> _commands = new List<IContainerCommand>();

        public override void Execute(IContainer container)
        {
            _commands.ForEach(command => command.Execute(container));
            _soCommands.ForEach(commnad => commnad.Execute(container));
        }

        public void Inject(IContainerCommand command)
        {
            _commands.Add(command);
        }
        
        public void Remove(IContainerCommand command)
        {
            _commands.Remove(command);
        }
    }
}