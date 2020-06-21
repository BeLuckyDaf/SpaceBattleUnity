using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using Nakama;
using UnityEngine;
using UnityEngine.Assertions;

namespace Managers
{
    /// <summary>
    /// Manipulates and maintains current Nakama session.
    /// </summary>
    public class SessionManager : MonoBehaviour
    {
        [SerializeField] private string _serverAddress;
        [SerializeField] private int _serverPort = 7350;

        private Client _client;
        private ISession _session;
        private ISocket _socket;

        /// <summary>
        /// Initializes the client.
        /// </summary>
        private void Start()
        {
            CreateClient();
            CreateSocket();
        }

        /// <summary>
        /// Closes everything that's got to be closed.
        /// </summary>
        private async void OnDisable()
        {
            if (_socket != null) await _socket.CloseAsync();
        }

        /// <summary>
        /// Creates a Nakama Client object instance.
        /// </summary>
        private void CreateClient()
        {
            _client = new Client("http", _serverAddress, _serverPort, "defaultkey");
            Debug.Log("Nakama client created.");
        }

        /// <summary>
        /// Uses Nakama Client created previously to authenticate via
        /// email and password.
        /// </summary>
        /// <param name="email">Account email</param>
        /// <param name="password">Account password</param>
        public async void LoginEmail(string email, string password)
        {
            try
            {
                _session = await _client.AuthenticateEmailAsync(email, password);
            }
            catch (Exception exception)
            {
                Debug.Log($"Login unsuccessful, error: {exception.Message}");
            }

            if (IsLoggedIn())
            {
                Debug.Log($"Logged in as {_session.Username}, session expires at {_session.ExpireTime}.");
                GameEventMessage.SendEvent("UserLoggedIn");
            }
            else
            {
                GameEventMessage.SendEvent("UserBadLogin");
            }
        }

        /// <summary>
        /// Creates client socket.
        /// </summary>
        private void CreateSocket()
        {
            _socket = _client.NewSocket();
        }

        /// <summary>
        /// Log out and clean up the session manager.
        /// </summary>
        public async void LogOut()
        {
            if (_socket != null) await _socket.CloseAsync();
            _socket = null;
            _session = null;
            GameEventMessage.SendEvent("UserLoggedOut");
        }

        /// <summary>
        /// Checks if the session manager client is ready.
        /// </summary>
        /// <returns>true if logged in, false otherwise</returns>
        public bool IsReady()
        {
            return _client != null;
        }
        
        /// <summary>
        /// Checks if currently logged into an account.
        /// </summary>
        /// <returns>true if logged in, false otherwise</returns>
        public bool IsLoggedIn()
        {
            return _session != null && !_session.IsExpired;
        }
    }
}
