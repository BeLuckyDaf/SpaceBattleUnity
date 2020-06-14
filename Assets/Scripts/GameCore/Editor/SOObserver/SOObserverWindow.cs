using UnityEditor;
using UnityEngine;

namespace GameCore.Editor.SOObserver
{
    public class SOObserverWindow : EditorWindow
    {
        private int a;
        private SOObserverGroup _group;
        private Vector2 _scroll;

        [MenuItem("Tools/SOObserver")]
        static void DrawWindow()
        {
            EditorWindow window = EditorWindow.GetWindow<SOObserverWindow>();
            window.titleContent =  new GUIContent("SOObserver");
            //window.Show();
        }
        
        

        private void OnGUI()
        {
            
            _group = EditorGUILayout.ObjectField("Group", _group, typeof(SOObserverGroup), false) as SOObserverGroup;
            if (_group == null)
            {
                EditorGUILayout.HelpBox("Select group", MessageType.Warning);
                return;
            }
            
            this.titleContent = new GUIContent(_group.GroupHeader);

            _scroll = GUILayout.BeginScrollView(_scroll);
            foreach (var variable in _group.Entries)
            {
                //GUILayout.BeginVertical();
                //GUILayout.Box(variable.Description);
                variable.IsFolded = EditorGUILayout.Foldout(variable.IsFolded, variable.Header);
                if (variable.IsFolded)
                {
                    EditorGUILayout.Space();
                    var tempEditor = UnityEditor.Editor.CreateEditor(variable.SO);
                    tempEditor.OnInspectorGUI();
                    if(variable.Info.Length > 0)
                        EditorGUILayout.HelpBox(variable.Info, MessageType.Info);
                    if(variable.WarningMessage.Length > 0)
                        EditorGUILayout.HelpBox(variable.WarningMessage, MessageType.Warning);
                    EditorGUILayout.Space();
                }

                //GUILayout.EndVertical();
            }
            GUILayout.EndScrollView();
        }
    }
}