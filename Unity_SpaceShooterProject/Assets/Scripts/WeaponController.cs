using UnityEngine;

namespace Assets.Scripts
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject shot;
        public Transform shotSpawn;
        public float fireRate;
        public float delayFire;

        private AudioSource _audioSource;
        
        // Use this for initialization
        void Start ()
        {
            _audioSource = GetComponent<AudioSource>();
            InvokeRepeating("Fire", delayFire, fireRate);
        }

        void Fire()
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            _audioSource.Play();
        }
    }
}
