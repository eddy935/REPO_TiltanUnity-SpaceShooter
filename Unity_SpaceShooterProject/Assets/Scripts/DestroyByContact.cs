using UnityEngine;



public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;

    private GameController _gameControllerRef;

    void Start()
    {
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
        if (other.tag == "boundary" || other.tag == "Enemy")
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
        }
        _gameControllerRef.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

