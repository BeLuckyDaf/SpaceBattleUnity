using System.Collections.Generic;
using GameCore.ContainerComponentModel.Containers;
using GameCore.ContainerComponentModel.Installers;
using UnityEditor;
using UnityEditor.Experimental.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using IComponent = GameCore.ContainerComponentModel.Interfaces.IComponent;

namespace GameCore.Editor
{
    [CustomEditor(typeof(MonoContainer), true)]
    public class MonoContainerDrawer : UnityEditor.Editor
    {
        public MonoContainer _target => (MonoContainer) target;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (_target.UseCustomTopContainer)
            {
                SerializedProperty topContainer = serializedObject.FindProperty("_topContainer");
                EditorGUILayout.ObjectField(topContainer);
            }
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Collect"))
            {
                CollectDependencies();
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void CollectDependencies()
        {
            MonoContainer container = (MonoContainer) target;
            container.MonoInstallers = CollectMonoInstallers(container.gameObject);
            container.MonoComponents = CollectMonoComponents(container.gameObject);
            var prefabStage = PrefabStageUtility.GetCurrentPrefabStage();
            if (prefabStage != null)
            {
                EditorSceneManager.MarkSceneDirty(prefabStage.scene);
            }
        }

        private List<AMonoInstaller> CollectMonoInstallers(GameObject go)
        {
            List<AMonoInstaller> result = new List<AMonoInstaller>();
            result.AddRange(go.GetComponents<AMonoInstaller>());
            for (int i = 0; i < go.transform.childCount; i++)
            {
                MonoContainer container = go.transform.GetChild(i).gameObject.GetComponent<MonoContainer>();
                if(container != null)
                    continue;
                result.AddRange(CollectMonoInstallers(go.transform.GetChild(i).gameObject));
            }
            return result;
        }
        
        private List<MonoBehaviour> CollectMonoComponents(GameObject go)
        {
            List<MonoBehaviour> result = new List<MonoBehaviour>();

            foreach (MonoBehaviour component in go.GetComponents<MonoBehaviour>())
            {
                if(component is IComponent)
                    result.Add(component);
            }

            for (int i = 0; i < go.transform.childCount; i++)
            {
                Transform child = go.transform.GetChild(i);
                
                if(child.gameObject.GetComponent<MonoInstaller>() != null || child.gameObject.GetComponent<MonoContainer>() != null)
                    continue;
                
                result.AddRange(CollectMonoComponents(child.gameObject));
            }
            
            return result;
        }
    }
}