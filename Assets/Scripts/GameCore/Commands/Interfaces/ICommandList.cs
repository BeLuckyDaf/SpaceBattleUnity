namespace GameCore.Commands.Interfaces
{
    public interface ICommandList : ICommand
    {
        void Inject(ICommand command);
        void Remove(ICommand command);
    }
}