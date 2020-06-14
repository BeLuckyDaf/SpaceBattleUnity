namespace GameCore.ContainerComponentModel.Interfaces
{
    /// <summary>
    /// default interface for components
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// register component into container
        /// </summary>
        /// <param name="container"></param>
        void Register(IContainer container);
    }
}