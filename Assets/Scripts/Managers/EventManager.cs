using System;
using System.Collections;
using System.Collections.Generic;
using Nakama;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    /// <summary>
    /// Stores all events to be used throughout the game.
    ///
    /// Warning: this is not ideal, because any object can cause any event they want.
    /// </summary>
    public class EventManager : MonoBehaviour
    {
        public UnityEvent OnSessionManagerLoggedIn;
        public UnityEvent OnSessionManagerReady;
    }
}