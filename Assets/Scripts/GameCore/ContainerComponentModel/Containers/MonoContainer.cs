using System;
using System.Collections.Generic;
using GameCore.ContainerComponentModel.Installers;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;
using IContainer = GameCore.ContainerComponentModel.Interfaces.IContainer;

namespace GameCore.ContainerComponentModel.Containers
{
    /// <summary>
    /// scope - gameObject
    /// </summary>
    public class MonoContainer : MonoBehaviour, IContainer
    {
        [SerializeField] protected List<AMonoInstaller> _monoInstallers = new List<AMonoInstaller>();
        [SerializeField] protected List<MonoBehaviour> _monoComponents = new List<MonoBehaviour>();
        [SerializeField] protected List<ASOInstaller> _soInstallers = new List<ASOInstaller>();
        [SerializeField] protected List<ScriptableObject> _soComponents = new List<ScriptableObject>();
        [SerializeField] protected bool _useCustomTopContainer;
        [SerializeField,HideInInspector] protected MonoContainer _topContainer;


        public List<AMonoInstaller> MonoInstallers
        {
            get => _monoInstallers;
            set => _monoInstallers = value;
        }
        public List<MonoBehaviour> MonoComponents
        {
            get => _monoComponents;
            set => _monoComponents = value;
        }
        public bool UseCustomTopContainer => _useCustomTopContainer;

        protected IContainer _container;
        protected bool _installed;

        protected virtual void Awake()
        {
            Init();
        }

        public virtual void Install()
        {
            if(_installed)
                return;
            
            CreateContainer();
            _container.Bind<GameObject>(this.gameObject);
            _monoInstallers.ForEach(installer => installer.Install(this));
            _soInstallers.ForEach(installer => installer.Install(this));
            _monoComponents.ForEach(component => ((IComponent) component).Register(this));
            _soComponents.ForEach(component => ((IComponent) component).Register(this));
            _container.Install();
            _installed = true;
        }
        
        public void Init()
        {
            if(!_installed)
                Install();
            
            _container.Init();
        }

        protected virtual void CreateContainer()
        {
            _container = _useCustomTopContainer ? new Container(_topContainer) : new Container(SceneContainer.Instance);
        }

        public virtual T Component<T>()
        {
            return _container.Component<T>();
        }

        public object Component(Type type)
        {
            return _container.Component(type);
        }

        public void Bind<T>(T component)
        {
            _container.Bind<T>(component);
        }

        public void Inject(object obj)
        {
            _container.Inject(obj);
        }

        public void RegisterInitializable(IInitializable initializable)
        {
            _container.RegisterInitializable(initializable);
        }

        public void SetTopContainer(IContainer container)
        {
            _container.SetTopContainer(container);
        }

        public bool TryGetComponent<T>(out T component)
        {
            return _container.TryGetComponent<T>(out component);
        }

        public void Inject<T>(T obj)
        {
            _container.Inject<T>(obj);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            for (int i = _monoComponents.Count-1; i >= 0; i--)
            {
                if (_monoComponents[i] is IComponent)
                    continue;
                
                Debug.Log($"{_monoComponents[i].GetType()} should implement IComponent interface", _monoComponents[i]);
                _monoComponents.RemoveAt(i);
            }
            for (int i = _soComponents.Count-1; i >= 0; i--)
            {
                if (_soComponents[i] is IComponent)
                    continue;
                
                Debug.Log($"{_soComponents[i].GetType()} should implement IComponent interface", _soComponents[i]);
                _soComponents.RemoveAt(i);
            }

            if (_topContainer == this)
            {
                Debug.LogError("TopContainer can't be the same as the target container", this);
                _topContainer = null;
            }
        }
#endif        
    }
}