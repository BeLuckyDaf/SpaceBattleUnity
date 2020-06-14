namespace GameCore.ContainerComponentModel.Interfaces
{
    /// <summary>
    /// responsibility - to pass components into container
    /// </summary>
    public interface IInstaller
    {
        /// <summary>
        /// installs components into container
        /// </summary>
        /// <param name="container"></param>
        void Install(IContainer container);
    }
}