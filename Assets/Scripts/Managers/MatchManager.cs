using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doozy.Engine;
using Nakama;
using UnityEngine;

namespace Managers
{
    public class MatchManager : MonoBehaviour
    {
        private ISocket _socket;

        public IMatch CurrentMatch { get; private set; }

        public async void InitSocket()
        {
            _socket = await ManagerContainer.Instance.SessionManager.CreateSocket();
        }

        public async Task<string> ListMatches()
        {
            if (_socket == null) return null;
            var matches = (await _socket.RpcAsync("get_my_active_matches")).Payload;
            Debug.Log($"MATCHES: {matches}");
            return matches;
        }
        
        public async Task<string> CreateMatch()
        {
            if (_socket == null) return null;
            var username = ManagerContainer.Instance.SessionManager.Session.Username;
            var matchId = (await _socket.RpcAsync("create_match_rpc", $"{{\"name\": \"{username}\"}}")).Payload;
            Debug.Log($"MatchId Created: {matchId}");
            GameEventMessage.SendEvent("UserCreatedMatch");
            return matchId;
        }
        
        public async Task<IMatch> JoinMatch(string matchId)
        {
            if (_socket == null || CurrentMatch != null)
            {
                Debug.Log("Already joined a match.");
                return null;
            }
            CurrentMatch = (await _socket.JoinMatchAsync(matchId));
            Debug.Log($"Match Joined: {CurrentMatch}");
            GameEventMessage.SendEvent("UserJoinedMatch");
            return CurrentMatch;
        }
    }
}
