using UnityEngine;

namespace Assets.Scripts
{
    public class DestroyByContact : MonoBehaviour
    {
        public GameObject explosion;
        public GameObject playerExplosion;

        public int scoreValue;

        private GameController _gameControllerRef;
        private DestroyByHealth _destroyByHealthRef;

        void Start()
        {
            _destroyByHealthRef = GetComponent<DestroyByHealth>();
            var gameControllerObj = GameObject.FindWithTag("GameController");
            if (gameControllerObj != null)
            {
                _gameControllerRef = gameControllerObj.GetComponent<GameController>();
            }

            if (gameControllerObj == null)
            {
                Debug.Log("Cannot find GameControllerRef script!!!");
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Boss" || other.tag == "Enemy")
            {
                return;
            }

            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);

            }

            if (other.tag == "Player")
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                _gameControllerRef.GameOver();
                DestroyGameObject(other);
            }
            if (other.tag == "PlayerShot")
            {
                _destroyByHealthRef.DecreaseHealth();
            }
            if (_destroyByHealthRef.health <= 0)
            {
                if(tag == "Boss")
                {
                    _gameControllerRef.BossDestroyed();
                }
                _gameControllerRef.AddScore(scoreValue);
                DestroyGameObject(other);
            }

        }
        public void DestroyGameObject(Collider other)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
