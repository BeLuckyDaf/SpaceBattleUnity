using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{   
    public class MatchController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _matchNameField;
        
        public async void ListMatches()
        {
            await ManagerContainer.Instance.MatchManager.ListMatches();
        }
    
        public async void CreateQuickMatch()
        {
            var matchId = await ManagerContainer.Instance.MatchManager.CreateMatch();
            _matchNameField.text = matchId;
        }
    
        public async void JoinQuickMatch()
        {
            await ManagerContainer.Instance.MatchManager.JoinMatch(_matchNameField.text);
        }
    }
}
