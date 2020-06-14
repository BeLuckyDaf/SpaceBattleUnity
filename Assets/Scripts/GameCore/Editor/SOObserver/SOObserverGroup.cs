using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameCore.Editor.SOObserver
{
    [CreateAssetMenu(menuName = "Game/ObserverWindow/ObserverGroup")]
    public class SOObserverGroup : ScriptableObject
    {
        [SerializeField] private string _groupHeader;
        [SerializeField] private SOObserverEntry[] _entries;

        public string GroupHeader => _groupHeader;
        public SOObserverEntry[] Entries => _entries;
    }

    
    [System.Serializable]
    public class SOObserverEntry
    {
        public ScriptableObject SO;
        [FormerlySerializedAs("Description")] public string Header;
        [TextArea] public string WarningMessage;
        [TextArea] public string Info;
        [NonSerialized] public bool IsFolded;
    }
    
    
}