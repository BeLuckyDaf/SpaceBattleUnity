#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameCore.Editor
{
    [InitializeOnLoad]
    public static class HierarchyWindowHeader
    {
        static HierarchyWindowHeader()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
        }

        static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (gameObject != null && gameObject.name.StartsWith("---", System.StringComparison.Ordinal))
            {
                EditorGUI.DrawRect(new Rect(selectionRect.x , selectionRect.y, selectionRect.width, selectionRect.height), Color.gray);
                EditorGUI.LabelField(selectionRect, gameObject.name.Replace("-", ""));
            }
        }
    }
}
#endif