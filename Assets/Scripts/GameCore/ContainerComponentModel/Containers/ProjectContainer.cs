namespace GameCore.ContainerComponentModel.Containers
{
    /// <summary>
    /// scope - whole project
    /// </summary>
    public class ProjectContainer : MonoContainer
    {
        private static ProjectContainer _instance;
        public static ProjectContainer Instance => _instance;

        public override void Install()
        {
            _instance = this;
            DontDestroyOnLoad(this);
            base.Install();
        }

        protected override void CreateContainer()
        {
            _container = new Container(_topContainer);
        }
    }
}