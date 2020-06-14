using System.Collections.Generic;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.ContainerComponentModel.Installers
{
    /// <summary>
    /// default SO installer
    /// installs all SO components passed into _components
    /// </summary>
    [CreateAssetMenu(menuName = "GameCore/ContainerComponentModel/SOInstaller")]
    public class SOInstaller : ASOInstaller
    {
        [SerializeField] private List<ScriptableObject> _components = new List<ScriptableObject>();
        
        public override void Install(IContainer container)
        {
            foreach (var component in _components)
            {
                var c = (IComponent) component;
                c.Register(container);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            for (int i = _components.Count-1; i >= 0; i--)
            {
                if (_components[i] is IComponent)
                    continue;
                
                Debug.Log($"{_components[i].GetType()} should implement IComponent interface", _components[i]);
                _components.RemoveAt(i);
                
            }
        }
#endif
    }
}