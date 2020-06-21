using System;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private ManagerContainer _managers;
        [SerializeField] private string _serverAddress;
        [SerializeField] private int _serverPort = 7350;

        private Client _client;
        private ISession _session;
        private Socket _socket;

        /// <summary>
        /// Initializes Nakama Client and checks that all components are intact.
        /// </summary>
        private void Start()
        {
            CreateClient();
        }

        /// <summary>
        /// Closes everything that's got to be closed.
        /// </summary>
        private async void OnDisable()
        {
            if (_socket != null) await _socket.CloseAsync();
        }

        /// <summary>
        /// Creates a Nakama Client object instance
        /// </summary>
        public void CreateClient()
        {
            _client = new Client("http", _serverAddress, _serverPort, "defaultkey");
            Debug.Log("Nakama client created.");
            _managers.EventManager.OnSessionManagerReady.Invoke();
        }

        /// <summary>
        /// Uses Nakama Client created previously to authenticate via
        /// email and password.
        /// </summary>
        /// <param name="email">Account email</param>
        /// <param name="password">Account password</param>
        public async void LoginWithPassword(string email, string password)
        {
            _session = await _client.AuthenticateEmailAsync(email, password);
            if (IsLoggedIn())
            {
                Debug.Log($"Logged in as {_session.Username}.");
                _managers.EventManager.OnSessionManagerLoggedIn.Invoke();
            }
        }

        /// <summary>
        /// Checks if currently logged into an account
        /// </summary>
        /// <returns>true if logged in, false otherwise</returns>
        public bool IsLoggedIn()
        {
            return _session != null && !_session.IsExpired;
        }
    }
}