using UnityEngine;

namespace Assets.Scripts
{
    public class Mover : MonoBehaviour
    {
        public float speed;

        private Rigidbody _rigidbody;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.velocity = transform.forward * speed;
        }
    }
}
