using UnityEngine;
using UnityEngine.EventSystems;

namespace AVP.FPSCounter.Movement
{
    public class CounterMovement : MonoBehaviour, IPointerDownHandler, IDragHandler 
    {
        [SerializeField] private FrameCounter _counter;

        private Vector2 _movingOffset;
        
        public void OnPointerDown(PointerEventData eventData) => _movingOffset = (Vector2)_counter.transform.position - eventData.position;

        public void OnDrag(PointerEventData eventData) => SetCounterPosition(eventData.position + _movingOffset);

        private void SetCounterPosition(Vector2 position) => _counter.transform.position = position;
    }
}
