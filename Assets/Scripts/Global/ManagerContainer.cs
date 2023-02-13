using System;
using System.Collections;
using System.Collections.Generic;
using Session;
using UnityEngine;
using UnityEngine.Assertions;

namespace Global
{
    /// <summary>
    /// Makes all managers globally accessible.
    /// </summary>
    [RequireComponent(typeof(SessionManager))]
    [RequireComponent(typeof(MatchManager))]
    public class ManagerContainer : MonoBehaviour
    {
        public static ManagerContainer Instance { get; private set; }

        public SessionManager SessionManager { get; private set; }
        public MatchManager MatchManager { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SessionManager = GetComponent<SessionManager>();
            MatchManager = GetComponent<MatchManager>();
            
            Assert.IsNotNull(SessionManager);
            Assert.IsNotNull(MatchManager);
        }
    }
}
