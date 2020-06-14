using GameCore.Commands.Interfaces;
using GameCore.Commands.SimpleCommands;
using UnityEditor;
using UnityEngine;

namespace GameCore.CommonStructures
{
    /// <summary>
    /// command list wrapped into so
    /// </summary>
    [CreateAssetMenu(menuName = "GameCore/Commands/GameEvent")]
    public class GameEvent : ScriptableObject, ICommandList
    {
        [SerializeField] protected CommandList _commandList = new CommandList();

        public int CommandsCount => _commandList.CommandsCount;

        public void Execute()
        {
            _commandList.Execute();
        }

        public void Inject(ICommand command)
        {
            _commandList.Inject(command);
        }

        public void Remove(ICommand command)
        {
            _commandList.Remove(command);
        }
        
        
#if UNITY_EDITOR
        [CanEditMultipleObjects]
        [CustomEditor(typeof(GameEvent))]
        public class GameEventEditor : Editor
        {
            public override void OnInspectorGUI()
            {
                GUILayout.Label($"Enqueued: {((GameEvent) target).CommandsCount} commands");
                if (GUILayout.Button("Execute"))
                {
                    ((GameEvent) target).Execute();
                }
            }
        }
    
#endif
    }
}