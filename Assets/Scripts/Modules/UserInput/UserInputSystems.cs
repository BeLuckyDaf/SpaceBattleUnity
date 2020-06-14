using UnityEngine;
using Modules.Root;
using Leopotam.Ecs;

namespace Modules.UserInput
{
    [CreateAssetMenu(menuName = "Modules/UserInput/Provider")]
    public class UserInputSystems : ScriptableObject, ISystemsProvider
    {
        public EcsSystems GetSystems(EcsWorld world, EcsSystems endFrame, EcsSystems ecsSystems)
        {
            EcsSystems systems = new EcsSystems(world, this.name);

            systems
                .Add(new TapTrackerSystem())
                ;

            endFrame
                .OneFrame<PointerDown>()
                .OneFrame<PointerClick>()
                .OneFrame<PointerUp>()
                ;

            return systems;
        }
    }
}
