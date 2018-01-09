using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts
{
    public class TouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _touched;
        private int _pointerId;
        private bool _canFire;

        void Awake()
        {
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
                _canFire = true;
            }
        }

        public void OnPointerUp(PointerEventData data)
        {
            //Restet Everything
            if (data.pointerId == _pointerId)
            {
                _canFire = false;
                _touched = false;
            }
        }

        public bool CanFire()
        {
            return _canFire;
        }

    }
}
