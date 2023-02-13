using System.Collections.Generic;
using System.Threading.Tasks;
using Doozy.Engine;
using Global;
using Nakama.TinyJson;
using Networking.Data;
using TMPro;
using UnityEngine;

namespace UI
{   
    public class MatchController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _matchNameField;
        
        public async void ListMatches()
        {
            await ManagerContainer.Instance.MatchManager.UpdateMatchList();
            var matchList = ManagerContainer.Instance.MatchManager.MatchList;
            foreach (var matchListEntry in matchList)
            {
                Debug.Log($"ID: {matchListEntry.match_id}, SERVER-AUTHORITATIVE: {matchListEntry.authoritative}");
            }
        }
    
        public async void CreateQuickMatch()
        {
            var matchId = await ManagerContainer.Instance.MatchManager.CreateMatch();
            _matchNameField.text = matchId;
        }
    
        public void JoinQuickMatch()
        {
            ManagerContainer.Instance.MatchManager.MatchToJoin = _matchNameField.text;
            GameEventMessage.SendEvent("MatchReadyToJoin");
        }
    }
}
