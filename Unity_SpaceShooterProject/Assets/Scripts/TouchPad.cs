using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class TouchPad : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float smoothing;

        private Vector2 _origin;
        private Vector2 _direction;
        private Vector2 _smoothDirection;
        private bool _touched;
        private int _pointerId;

        void Awake()
        {
            _direction = Vector2.zero;
            _touched = false;
        }

        public void OnPointerDown(PointerEventData data)
        {
            //Set Our start Point   
            if (!_touched)
            {
                //data - current event data
                _touched = true;
                _pointerId = data.pointerId;
                _origin = data.position;
            }
        }

        public void OnDrag(PointerEventData data)
        {
            //Compare the difference betwen our start point and current pointer pos
            if (data.pointerId == _pointerId)
            {
                var currentPosition = data.position;
                var directionRaw = currentPosition - _origin;
                _direction = directionRaw.normalized;
            }
        }

        public void OnPointerUp(PointerEventData data)
        {
            //Restet Everything
            if (data.pointerId == _pointerId)
            {
                _direction = Vector2.zero;
                _touched = false;
            }
        }

        public Vector2 GetDirection()
        {
            _smoothDirection = Vector2.MoveTowards(_smoothDirection, _direction, smoothing);
            return _direction;
        }
    }

}
