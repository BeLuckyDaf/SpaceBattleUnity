using Leopotam.Ecs;
using UnityEngine;

namespace Modules.ViewHub
{
    [EcsAutoResetCheck]
    public struct UnityView
    {
        public string id;
        public GameObject GameObject;
        public Transform Transform;

        public static void CustomReset(ref UnityView c)
        {
            c.id = null;
            if (c.GameObject != null)
                Object.Destroy(c.GameObject);
            c.GameObject = null;
            c.Transform = null;
        }
    }
}