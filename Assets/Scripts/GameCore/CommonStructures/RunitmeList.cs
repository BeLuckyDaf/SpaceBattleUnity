using System.Collections.Generic;
using GameCore.ContainerComponentModel.Interfaces;
using UnityEngine;

namespace GameCore.CommonStructures
{
    /// <summary>
    /// list of containers wrapped into so
    /// </summary>
    [CreateAssetMenu(menuName = "GameCore/RuntimeList")]
    public class RunitmeList : ScriptableObject
    {
        public List<IContainer> Containers = new List<IContainer>();

        public void Inject(IContainer container)
        {
            Containers.Add(container);
        }

        public void Remove(IContainer container)
        {
            Containers.Remove(container);
        }

    }
}