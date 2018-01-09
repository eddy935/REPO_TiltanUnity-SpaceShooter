using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        public GameObject[] hazards;
        public int hazardCount;

        public Vector3 spawnValue;
        public float spawnWait;
        public float startWait;
        public float waveWait;

        public Text scoreText;
        public Text gameOverText;
        public GameObject restartButton;

        private bool _isGameOver;
        private int _score;

        void Start()
        {
            _isGameOver = false;
            restartButton.SetActive(false);
            gameOverText.text = "";
            _score = 0;
            UpdateScore();
            StartCoroutine(SpawnWaves());
        }

        void Update()
        {
            if (_isGameOver)
            {
                restartButton.SetActive(true);
            }
            //  if (_restart)
            //  {
            //      if (Input.GetKeyDown(KeyCode.R))
            //      {
            //          SceneManager.LoadScene("Game");
            //      }
            //  }
        }

        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    var hazard = hazards[Random.Range(0, hazards.Length)];
                    var spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                    var spawnRotation = Quaternion.identity;

                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
            }
        }

        public void AddScore(int newScoreValue)
        {
            _score += newScoreValue;
            UpdateScore();
        }

        void UpdateScore()
        {
            scoreText.text = "Score: " + _score;
        }

        public void GameOver()
        {
            gameOverText.text = "GAME OVER";
            _isGameOver = true;
        }

        public void RestartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
