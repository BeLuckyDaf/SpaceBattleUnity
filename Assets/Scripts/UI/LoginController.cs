using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace UI
{
    public class LoginController : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _passwordField;

        /// <summary>
        /// Uses UI data to call login from session manager.
        /// </summary>
        public void Login()
        {
            Assert.IsNotNull(ManagerContainer.Instance);
            ManagerContainer.Instance.SessionManager.LoginEmail(_emailField.text, _passwordField.text);
        }
    }
}