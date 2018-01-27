using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }


    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float tilt;
        public Boundary boundary;

        public GameObject shot;
        public Transform shotSpwan;
        public Transform[] shotSpwans;
        public float fireRate;

        public TouchPad touchPad;
        public TouchAreaButton areaButton;

        private Rigidbody _rigidBody;
        private float _nextFire;
        private AudioSource _audioSource;
        public bool isDoubleGun;

        private Quaternion _calibrationQuaternion;

        void Start()
        {
            Calibrateaccelerometer();
            _rigidBody = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            // if (areaButton.CanFire() && Time.time > _nextFire)
            // {
            //     _nextFire = Time.time + fireRate;
            //     Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
            //     _audioSource.Play();
            // }
            if (Input.GetKey(KeyCode.LeftControl) && Time.time > _nextFire)
            {
                _nextFire = Time.time + fireRate;
                if (!isDoubleGun)
                {
                    Debug.Log("singleGun");
                    Instantiate(shot, shotSpwan.position, shotSpwan.rotation);
                    _audioSource.Play();
                }
                else if(isDoubleGun)
                {
                    foreach (var shotSpawn in shotSpwans)
                    {
                        Debug.Log("doubleGun");
                        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                        _audioSource.Play();
                    }
                }
            }
        }


        /*
         * GYRO CONTROLS
         * The next 2 functions are used to get the original & final rotation when tilting the phone
         */
        //Used to calibrate the Input.acceleration input
        void Calibrateaccelerometer()
        {
            var accelerationSnapshot = Input.acceleration;
            var rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
            _calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
        }

        //Get the 'Calibrated' value from the device
        Vector3 FixAcceleration(Vector3 acceleration)
        {
            var fixedAcceleration = _calibrationQuaternion * acceleration;
            return fixedAcceleration;
        }

        //Will execute the code once per physics step 
        void FixedUpdate()
        {
            //DEFAULT CONTROLS

            //var moveHorizontal = Input.GetAxis("Horizontal");
            //var moveVertical = Input.GetAxis("Vertical");
            //
            //var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            //----

            //MOBILE CONTORLS

            //var accelerationRaw = Input.acceleration;
            //var acceleration = FixAcceleration(accelerationRaw);
            //var movement = new Vector3(acceleration.x, 0.0f, acceleration.y);

            var direction = touchPad.GetDirection();
            var movement = new Vector3(direction.x, 0.0f, direction.y);

            _rigidBody.velocity = movement * speed;

            _rigidBody.position = new Vector3
             (
              Mathf.Clamp(_rigidBody.position.x, boundary.xMin, boundary.xMax),
              0.0f,
              Mathf.Clamp(_rigidBody.position.z, boundary.zMin, boundary.zMax)
             );

            _rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidBody.velocity.x * -tilt);
        }


    }
}
