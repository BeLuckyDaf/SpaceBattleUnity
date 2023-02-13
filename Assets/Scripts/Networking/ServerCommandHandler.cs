using System;
using System.Text;
using Global;
using Match;
using Nakama;
using Networking.Common;
using UnityEngine;
using UnityEngine.Assertions;

namespace Networking
{
    public class ServerCommandHandler : MonoBehaviour
    {
        [SerializeField] private WorldLoader _worldLoader;

        private ISocket _socket; 
        
        private async void Start()
        {
            _socket = ManagerContainer.Instance.MatchManager.Socket;
            _socket.ReceivedMatchState += OnReceivedMatchState;
            await ManagerContainer.Instance.MatchManager.JoinMatch();
        }

        private void OnDestroy()
        {
            _socket.ReceivedMatchState -= OnReceivedMatchState;
        }

        public void OnReceivedMatchState(IMatchState matchState)
        {
            var code = (ServerCommand) matchState.OpCode;
            var state = ParseBytes(matchState.State);
            switch (code)
            {
                case ServerCommand.StateSnapshot:
                    _worldLoader.LoadWorld(state);
                    break;
                case ServerCommand.PlayerJoined:
                    break;
                case ServerCommand.PlayerLeft:
                    break;
                case ServerCommand.PlayerMove:
                    break;
                case ServerCommand.PlayerBuyProperty:
                    break;
                case ServerCommand.PlayerUpgradeProperty:
                    break;
                case ServerCommand.PlayerAttackPlayer:
                    break;
                case ServerCommand.PlayerAttackProperty:
                    break;
                case ServerCommand.PlayerHeal:
                    break;
                case ServerCommand.PlayerKilled:
                    break;
                case ServerCommand.PlayerRespawned:
                    break;
                case ServerCommand.GamePause:
                    break;
                case ServerCommand.GameUnpause:
                    break;
                case ServerCommand.GameEnd:
                    break;
                case ServerCommand.GameServerMessage:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string ParseBytes(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}