using System;
using System.Collections.Generic;
using System.Reflection;
using GameCore.ContainerComponentModel.Interfaces;

namespace GameCore.ContainerComponentModel.Containers
{
    /// <summary>
    /// default realization of container
    /// registers/resolves dependencies
    /// </summary>
    public class Container : IContainer
    {
        private Dictionary<Type, object> _components;
        private List<IInstaller> _installers;
        private List<IInitializable> _initializables;
        private bool _installed;
        private bool _initialized;
        private IContainer _topContainer;
        
        public Container()
        {
            _components = new Dictionary<Type, object>();
            _installers = new List<IInstaller>();
            _initializables = new List<IInitializable>();
            _installed = false;
            _initialized = false;
        }

        public Container(IEnumerable<IInstaller> installers)
        {
            _components = new Dictionary<Type, object>();
            _installers = new List<IInstaller>(installers);
            _initializables = new List<IInitializable>();
            _installed = false;
            _initialized = false;
        }
        
        public Container(IContainer topContainer)
        {
            _components = new Dictionary<Type, object>();
            _installers = new List<IInstaller>();
            _initializables = new List<IInitializable>();
            _installed = false;
            _initialized = false;
            _topContainer = topContainer;
        }
        
        public void Install()
        {
            if(!_installed)
                _installers.ForEach(installer => installer.Install(this));
            _installed = true;
        }

        public void Init()
        {
            if(!_installed)
                Install();
            
            if(_initialized)
                return;
            
            foreach (var component in _components)
            {
                Inject(component.Value);
            }

            foreach (var initializable in _initializables)
            {
                initializable.Init();
            }

            _initialized = true;
        }

        public T Component<T>()
        {
            return (T) Component(typeof(T));
        }

        public void Bind<T>(T component)
        {
            Type t = typeof(T);
            if (!_components.ContainsKey(t))
                _components.Add(t, component);
            else
                _components[t] = component;
        }

        public object Component(System.Type type)
        {
            if (_components.TryGetValue(type, out var result))
            {
                return result;
            }

            if (_topContainer != null)
                return _topContainer.Component(type);
            
            throw new InjectorException($"{type.FullName} is not at container");
            return null;
        }

        public bool TryGetComponent<T>(out T component)
        {
            if (_components.TryGetValue(typeof(T), out var result))
            {
                component = (T) result;
                return true;
            }

            if (_topContainer != null)
            {
                return _topContainer.TryGetComponent(out component);
            }
            component = default(T);
            return false;
        }

        public void Inject(object obj)
        {
            FieldInfo[] fields = Reflector.Reflect(obj.GetType());
            int fieldsLength = fields.Length;
            FieldInfo field;
            for (int i = 0; i < fieldsLength; i++)
            {
                field = fields[i];
                field.SetValue(obj,Component(field.FieldType));
            }

        }

        public void Inject<T>(T obj)
        {
            FieldInfo[] fields = Reflector.Reflect(typeof(T));
            int fieldsLength = fields.Length;
            FieldInfo field;
            for (int i = 0; i < fieldsLength; i++)
            {
                field = fields[i];
                field.SetValue(obj,Component(field.FieldType));
            }
        }

        public void RegisterInitializable(IInitializable initializable)
        {
            _initializables.Add(initializable);
        }

        public void SetTopContainer(IContainer container)
        {
            _topContainer = container;
        }
    }
}