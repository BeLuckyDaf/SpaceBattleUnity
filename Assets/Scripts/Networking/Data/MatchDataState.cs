using System.Collections.Generic;

namespace Networking.Data
{
    public struct MatchDataState
    {
        public Dictionary<string, MatchDataPresence> Presences;
        public MatchDataRoom Room;
    }
}