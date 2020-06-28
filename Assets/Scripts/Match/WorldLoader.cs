using Nakama.TinyJson;
using Networking.Data;
using UnityEngine;

namespace Match
{
    public class WorldLoader : MonoBehaviour
    {
        private WorldSnapshot _worldSnapshot;

        public void UpdateWorldSnapshot(WorldSnapshot snapshot)
        {
            _worldSnapshot = snapshot;
        }

        public void UpdateWorldSnapshot(string snapshot)
        {
            UpdateWorldSnapshot(snapshot.FromJson<WorldSnapshot>());
        }

        public void LoadWorld(string snapshot)
        {
            UpdateWorldSnapshot(snapshot);
            LoadWorld();
        }
        
        public void LoadWorld()
        {
            foreach (var gameWorldPoint in _worldSnapshot.Room.GameWorld.Points)
            {
                var key = gameWorldPoint.Key;
                var x = gameWorldPoint.Value.Position.X;
                var y = gameWorldPoint.Value.Position.Y;
                var loctype = gameWorldPoint.Value.LocType;
                Debug.Log($"{key}:{x}:{y}:{loctype}");
            }
        }
    }
}