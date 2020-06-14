using System.Collections.Generic;
using GameCore.Commands.Interfaces;
using UnityEngine;

namespace GameCore.Commands.SimpleCommands
{
    [System.Serializable]
    public class CommandList : ICommandList
    {
        [SerializeField] protected List<ASOCommand> _soCommands = new List<ASOCommand>();
        protected List<ICommand> _commands = new List<ICommand>();

        public int CommandsCount => _commands.Count;

        public void Execute()
        {
            _commands.ForEach(command => command.Execute());
            _soCommands.ForEach(command => command.Execute());
        }

        public void Inject(ICommand command)
        {
            _commands.Add(command);
        }

        public void Remove(ICommand command)
        {
            _commands.Remove(command);
        }
    }
}