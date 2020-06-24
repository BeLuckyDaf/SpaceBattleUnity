using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        private ISocket _socket;

        public Client Client { get; private set; }
        public ISession Session { get; private set; }

        /// <summary>
        /// Initializes the client.
        /// </summary>
        private async void Start()
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
        /// Creates a Nakama Client object instance.
        /// </summary>
        private void CreateClient()
        {
            Client = new Client("http", _serverAddress, _serverPort, "defaultkey");
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
                Session = await Client.AuthenticateEmailAsync(email, password);
            }
            catch (Exception exception)
            {
                Debug.Log($"Login unsuccessful, error: {exception.Message}");
            }

            if (IsLoggedIn())
            {
                Debug.Log($"Logged in as {Session.Username}, session expires at {Session.ExpireTime}.");
                GameEventMessage.SendEvent("UserLoggedIn");
            }
            else
            {
                GameEventMessage.SendEvent("UserBadLogin");
            }
        }

        public async void InitSocket()
        {
            _socket = await CreateSocket();
        }

        /// <summary>
        /// Creates client socket.
        /// </summary>
        public async Task<ISocket> CreateSocket()
        {
            var socket = Client.NewSocket();
            await socket.ConnectAsync(Session);
            return socket;
        }

        /// <summary>
        /// Closes a Nakama socket.
        /// </summary>
        /// <param name="socket">Socket to close.</param>
        public async Task CloseSocket(ISocket socket)
        {
            if (socket != null) await socket.CloseAsync();
        }

        /// <summary>
        /// Cleans up the session manager.
        /// </summary>
        public async void CleanUp()
        {
            await CloseSocket(_socket);
            _socket = null;
            Session = null;
        }

        /// <summary>
        /// Checks if the session manager client is ready.
        /// </summary>
        /// <returns>true if logged in, false otherwise</returns>
        public bool IsReady()
        {
            return Client != null;
        }
        
        /// <summary>
        /// Checks if currently logged into an account.
        /// </summary>
        /// <returns>true if logged in, false otherwise</returns>
        public bool IsLoggedIn()
        {
            return Session != null && !Session.IsExpired;
        }
    }
}
