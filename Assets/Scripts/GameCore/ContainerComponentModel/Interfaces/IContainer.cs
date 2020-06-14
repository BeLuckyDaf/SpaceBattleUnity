namespace GameCore.ContainerComponentModel.Interfaces
{
    public interface IContainer
    {
        /// <summary>
        /// installs initial dependencies
        /// </summary>
        void Install();
        
        /// <summary>
        /// default init call. Binds & injects dependencies into components
        /// </summary>
        void Init();
        
        /// <summary>
        /// Takes component from container
        /// </summary>
        /// <typeparam name="T">type of a component</typeparam>
        /// <returns>Component of T</returns>
        T Component<T>();
        
        /// <summary>
        /// Takes component from container
        /// </summary>
        /// <typeparam name="T">type of a component</typeparam>
        /// <returns>Component of T</returns>
        object Component(System.Type type);
        
        /// <summary>
        /// Binds component to a container
        /// </summary>
        /// <param name="component">component to put</param>
        /// <typeparam name="T">type of a component</typeparam>
        void Bind<T>(T component);
        
        /// <summary>
        /// injects dependencies from container into object
        /// </summary>
        /// <param name="obj"></param>
        void Inject(object obj);

        /// <summary>
        /// injects dependencies from container into object
        /// </summary>
        /// <param name="obj"></param>
        /// <typeparam name="T"></typeparam>
        void Inject<T>(T obj);

        /// <summary>
        /// registers initializable component
        /// </summary>
        /// <param name="initializable"></param>
        void RegisterInitializable(IInitializable initializable);

        void SetTopContainer(IContainer container);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="component"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>true if sucess, false if fail</returns>
        bool TryGetComponent<T>(out T component);

    }
}