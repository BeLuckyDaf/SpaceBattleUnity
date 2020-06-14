using UnityEngine;

namespace GameCore.Variables
{
    [CreateAssetMenu(menuName = "GameCore/Variables/Transform")]
    public class TransformVariable : AVariable<Transform>{}
    
    [System.Serializable]
    public class TransformReference : AReference<TransformVariable, Transform>{}
}