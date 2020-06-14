using GameCore.Variables;
using UnityEngine;

namespace GameCore.Stuff
{
    public class TransformReferencer : MonoBehaviour
    {
        [SerializeField] private TransformReference _followPoint;

        private void Awake()
        {
            _followPoint.Value = transform;
        }
    }
}
