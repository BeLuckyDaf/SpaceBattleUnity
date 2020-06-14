using GameCore.Stuff;
using UnityEngine;

namespace GameCore.Variables
{
    [CreateAssetMenu(menuName = MenuConsts.VariableMenuPath+ "Color")]
    public class ColorVariable : AVariable<Color>{}
    
    [System.Serializable]
    public class ColorReference : AReference<ColorVariable, Color>{}
}