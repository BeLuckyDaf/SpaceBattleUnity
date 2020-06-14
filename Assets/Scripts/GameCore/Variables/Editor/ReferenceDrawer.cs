#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace GameCore.Variables.Editor
{
    
    [CustomPropertyDrawer(typeof(AReference), true)]
    public class ReferenceDrawer : PropertyDrawer
    {
        
        private readonly string[] popupOptions = { "Use Constant", "Use Variable" };
        private GUIStyle popupStyle;

        private SerializedProperty useReference;
        private SerializedProperty constantValue;
        private SerializedProperty variable;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            useReference = property.FindPropertyRelative("UseReference");
            constantValue = property.FindPropertyRelative("Constant");
            variable = property.FindPropertyRelative("Variable");

            return  EditorGUI.GetPropertyHeight(useReference.boolValue ? variable : constantValue) + 3;
            //return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            useReference = property.FindPropertyRelative("UseReference");
            constantValue = property.FindPropertyRelative("Constant");
            variable = property.FindPropertyRelative("Variable");

            using(new EditorGUI.PropertyScope(position, label, property))
            {
                position = EditorGUI.PrefixLabel(position, label);

                using(var check = new EditorGUI.ChangeCheckScope())
                {
                    Rect buttonRect = new Rect(position);
                    buttonRect.yMin += popupStyle.margin.top;
                    buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right + 10; // todo constant
                    buttonRect.xMin = position.xMin;
                    position.xMin = buttonRect.xMax;

                    int result = EditorGUI.Popup(buttonRect, useReference.boolValue ? 1 : 0, popupOptions, popupStyle);

                    useReference.boolValue = result == 1;

                    EditorGUI.PropertyField(position, useReference.boolValue ? variable : constantValue, GUIContent.none, true);
                    
                    

                    if (check.changed)
                    {
                        property.serializedObject.ApplyModifiedProperties();
                    }
                }
            }
        }

    }
}
#endif