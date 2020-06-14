using GameCore.Commands.Interfaces;

namespace GameCore.Commands.SimpleCommands
{
    public abstract class ASOCommand : ICommand
    {
        public abstract void Execute();
    }
}