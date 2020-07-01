using System.Collections.Generic;

namespace Networking.Data
{
    public struct MatchDataRoom
    {
        public MatchDataWorld GameWorld;
        public Dictionary<string, MatchDataPlayer> Players;
        public int MaxPlayers;
    }
}