namespace GameCore.ContainerComponentModel.Containers
{
    /// <summary>
    /// scope - active scene
    /// </summary>
    public class SceneContainer : MonoContainer
    {
        private static SceneContainer _instance;
        
        public static SceneContainer Instance => _instance;
        
        public override void Install()
        {
            _instance = this; // todo more complex singletone :/
            base.Install();
        }

        protected override void CreateContainer()
        {
            _container = _useCustomTopContainer ? new Container(_topContainer) : new Container(ProjectContainer.Instance);
        }
    }
}