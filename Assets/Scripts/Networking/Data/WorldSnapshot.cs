using System.Collections.Generic;

namespace Networking.Data
{
    public struct WorldSnapshot
    {
        public Dictionary<string, Presence> Presences;
        public Room Room;
    }
}