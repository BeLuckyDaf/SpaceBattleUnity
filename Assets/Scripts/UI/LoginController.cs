using System;
using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using Global;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class LoginController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _passwordField;

        public void TryRestore()
        {
            GameEventMessage.SendEvent(ManagerContainer.Instance.SessionManager.IsLoggedIn()
                ? "UserLoginRestored"
                : "UserLoginNeeded");
        }

        /// <summary>
        /// Uses UI data to call login from session manager.
        /// </summary>
        public void Login()
        {
            Assert.IsNotNull(ManagerContainer.Instance);
            ManagerContainer.Instance.SessionManager.LoginEmail(_emailField.text, _passwordField.text);
        }
        
        /// <summary>
        /// Uses session manager to log out.
        /// </summary>
        public void Logout()
        {
            Assert.IsNotNull(ManagerContainer.Instance);
            GameEventMessage.SendEvent("UserLoggedOut");
        }
    }
}