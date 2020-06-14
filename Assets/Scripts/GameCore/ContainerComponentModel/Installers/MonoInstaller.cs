using System;
using System.Collections.Generic;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.ContainerComponentModel.Installers
{
    /// <summary>
    /// default mono installer
    /// installs so & monobehaviours
    /// </summary>
    public class MonoInstaller : AMonoInstaller
    {
        [SerializeField] private List<MonoBehaviour> _monoBehaviours = new List<MonoBehaviour>();
        [SerializeField] private List<ScriptableObject> _scriptableObjects = new List<ScriptableObject>();
        
        public override void Install(IContainer container)
        {
            foreach (var component in _monoBehaviours)
            {
                var c = (IComponent) component;
                c.Register(container);
            }
            foreach (var component in _scriptableObjects)
            {
                var c = (IComponent) component;
                c.Register(container);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            for (int i = _monoBehaviours.Count-1; i >= 0; i--)
            {
                if (_monoBehaviours[i] is IComponent)
                    continue;
                
                Debug.Log($"{_monoBehaviours[i].GetType()} should implement IComponent interface", _monoBehaviours[i]);
                _monoBehaviours.RemoveAt(i);
            }
            for (int i = _scriptableObjects.Count-1; i >= 0; i--)
            {
                if (_scriptableObjects[i] is IComponent)
                    continue;
                
                Debug.Log($"{_scriptableObjects[i].GetType()} should implement IComponent interface", _scriptableObjects[i]);
                _scriptableObjects.RemoveAt(i);
            }
        }
#endif
    }
}