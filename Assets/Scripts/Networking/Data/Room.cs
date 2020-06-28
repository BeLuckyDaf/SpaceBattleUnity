using System.Collections.Generic;

namespace Networking.Data
{
    public struct Room
    {
        public World GameWorld;
        public Dictionary<string, Player> Players;
        public int MaxPlayers;
    }
}