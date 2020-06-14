using Leopotam.Ecs;
using Modules.Root;
using UnityEngine;

namespace Assets.Scripts.Modules.SBGame
{
    /// <summary>
    /// entry point for gameplay logic
    /// </summary>
    public class SBGameSystems : MonoBehaviour, ISystemsProvider
    {
        public EcsSystems GetSystems(EcsWorld world, EcsSystems endFrame, EcsSystems mainSystems)
        {
            EcsSystems systems = new EcsSystems(world, "SBGame");

            return systems;
        }
    }
}
