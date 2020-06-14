namespace GameCore.Commands.Interfaces
{
    public interface ICompositeCommandList: ICompositeCommand
    {
        void Inject(ICompositeCommand command);
        void Remove(ICompositeCommand command);
    }
}