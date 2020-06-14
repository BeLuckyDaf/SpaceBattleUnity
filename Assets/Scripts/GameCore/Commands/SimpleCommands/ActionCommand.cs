using System;
using GameCore.Commands.Interfaces;

namespace GameCore.Commands.SimpleCommands
{
    public class ActionCommand : ICommand
    {
        private readonly Action _action;

        public ActionCommand(Action action)
        {
            _action = action;
        }
        
        public void Execute()
        {
            _action.Invoke();
        }
    }
}