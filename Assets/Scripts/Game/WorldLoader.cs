using Nakama.TinyJson;
using Networking.Data;
using UnityEngine;
using UnityEngine.Assertions;

namespace Match
{
    public class WorldLoader : MonoBehaviour
    {
        private MatchDataState m_matchDataState;

        public void UpdateWorldSnapshot(MatchDataState snapshot)
        {
            m_matchDataState = snapshot;
        }

        public void UpdateWorldSnapshot(string snapshot)
        {
            UpdateWorldSnapshot(snapshot.FromJson<MatchDataState>());
        }

        public void LoadWorld(string snapshot)
        {
            UpdateWorldSnapshot(snapshot);
            LoadWorld();
        }
        
        public void LoadWorld()
        {
            Debug.Log(m_matchDataState.ToJson());
        }
    }
}