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
        public GameObject menuButton;
        public int bossTimer;
        public bool bossSpawned = false;

        public int bossSpawnWait;
        private bool _isGameOver;
        private int _score;
        private Coroutine coroutine;
        private Vector3 bossSpawnOffset;
        public int bossesKilled;

        void Start()
        {
            _isGameOver = false;
            restartButton.SetActive(false);
            menuButton.SetActive(false);
            gameOverText.text = "";
            _score = 0;
            UpdateScore();
            coroutine = StartCoroutine(SpawnWaves());
            bossSpawnOffset = new Vector3(0, 0, 21);
            RandomizeBossSpawnWait();
        }

        void Update()
        {
            ActivateRestartButton();
            bossTimer = (int)Mathf.Floor(Time.timeSinceLevelLoad);
            SpawnBossCaller();
        }

        void ActivateRestartButton()
        {
            if (_isGameOver)
            {
                restartButton.SetActive(true);
            }
        }

        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                if (!_isGameOver)
                {
                    for (int i = 0; i < hazardCount; i++)
                    {
                        var hazard = hazards[Random.Range(0, hazards.Length - 1)];
                        var spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                        var spawnRotation = Quaternion.identity;

                        Instantiate(hazard, spawnPosition, spawnRotation);
                        yield return new WaitForSeconds(spawnWait);
                    }
                    yield return new WaitForSeconds(waveWait);
                }
                else
                    yield return null;
            }
        }

        void SpawnBossCaller()
        {
            if (bossTimer == bossSpawnWait && bossSpawned == false)
            {
                StopCoroutine(coroutine);
                coroutine = StartCoroutine(SpawnBoss());
            }
        }

        IEnumerator SpawnBoss()
        {
            if (!_isGameOver)
            {
                bossSpawned = true;
                var hazard = hazards[hazards.Length - 1];
                var spawnPosition = bossSpawnOffset;
                var spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            else
                yield return null;
            StopCoroutine(coroutine);
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

        public void BossDestroyed()
        {
            coroutine = StartCoroutine(SpawnWaves());
            bossesKilled++;
            bossSpawned = false;
            RandomizeBossSpawnWait();
        }
        void RandomizeBossSpawnWait()
        {
            bossSpawnWait = Random.Range(5, 20) + bossTimer;
        }
    }
}
