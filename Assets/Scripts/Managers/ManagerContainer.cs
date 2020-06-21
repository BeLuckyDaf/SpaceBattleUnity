using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Managers
{
    public class ManagerContainer : MonoBehaviour
    {
        [SerializeField] private SessionManager _sessionManager;
        [SerializeField] private EventManager _eventManager;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        
            Assert.IsNotNull(_sessionManager);
            Assert.IsNotNull(_eventManager);
        }

        public SessionManager SessionManager
        {
            get => _sessionManager;
        }
    
        public EventManager EventManager
        {
            get => _eventManager;
        }
    }
}
