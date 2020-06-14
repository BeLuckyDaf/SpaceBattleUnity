using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace Modules.Utils.UnityComponents
{
    public class TapPunchScale : MonoBehaviour, IPointerDownHandler
    {
        [Header("Punch config")]
        [SerializeField] private Vector3 _punch = Vector3.one;
        [SerializeField] private float _duration = 0.33f;
        [SerializeField] private int _vibrato = 10;
        [SerializeField] private float _elasticity = 1;

        public void OnPointerDown(PointerEventData eventData)
        {
            transform.DOComplete();
            transform.DOPunchScale(_punch, _duration, _vibrato, _elasticity);
        }
    }
}
