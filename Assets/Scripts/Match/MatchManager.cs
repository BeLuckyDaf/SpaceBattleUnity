using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Doozy.Engine;
using Nakama;
using Nakama.TinyJson;
using Networking.Data;
using UnityEngine;

namespace Global
{
    public class MatchManager : MonoBehaviour
    {
        public ISocket Socket { get; private set; }

        public IMatch CurrentMatch { get; private set; }
        public string MatchToJoin { get; set; }
        public List<MatchDataListEntry> MatchList { get; private set; }
        
        public async void InitSocket()
        {
            Socket = await ManagerContainer.Instance.SessionManager.CreateSocket();
        }

        private async void OnDisable()
        {
            await ManagerContainer.Instance.SessionManager.CloseSocket(Socket);
            Socket = null;
        }

        public async Task UpdateMatchList()
        {
            if (Socket == null) return;
            var matches = (await Socket.RpcAsync("get_my_active_matches")).Payload;
            var matchList = matches.FromJson<List<MatchDataListEntry>>();
            // TODO: check if parsing error occurred
            MatchList = matchList;
        }
        
        public async Task<string> CreateMatch()
        {
            if (Socket == null) return null;
            var username = ManagerContainer.Instance.SessionManager.Session.Username;
            var matchId = (await Socket.RpcAsync("create_match_rpc", $"{{\"name\": \"{username}\"}}")).Payload;
            Debug.Log($"MatchId Created: {matchId}");
            GameEventMessage.SendEvent("UserCreatedMatch");
            return matchId;
        }
        
        public async Task<IMatch> JoinMatch()
        {
            if (Socket == null || CurrentMatch != null)
            {
                Debug.Log("Already joined a match.");
                return null;
            }
            CurrentMatch = (await Socket.JoinMatchAsync(MatchToJoin));
            Debug.Log($"Match Joined: {CurrentMatch}");
            GameEventMessage.SendEvent("UserJoinedMatch");
            return CurrentMatch;
        }
    }
}
