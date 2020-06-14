using UnityEditor;
using UnityEngine;

namespace GameCore.Variables
{
    public abstract class AVariable<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] public T _value;
        private T _runtimeValue;
        
        #if UNITY_EDITOR
        private T _deserializedValue;
        #endif
        
        public T Value
        {
            get => _runtimeValue;
            set => _runtimeValue = value;
        }

        public void OnBeforeSerialize()
        {
            #if UNITY_EDITOR
            if (!Equals(_deserializedValue, _value))
            {
                _runtimeValue = _value;
                _deserializedValue = _value;
            }
            #endif
            return;
        }

        public void OnAfterDeserialize()
        {
            #if UNITY_EDITOR
            _deserializedValue = _value;
            #endif
            _runtimeValue = _value;
            return;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator T(AVariable<T> t)
        {
            return t.Value;
        }
    }

    #if UNITY_EDITOR
    [CanEditMultipleObjects]
    [CustomEditor(typeof(AVariable<>), true)]
    public class VarEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            EditorGUILayout.LabelField($"Runtime value: {target.ToString()}");
        }
    }
    #endif
}
