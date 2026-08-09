using UnityEngine;
using UnityEngine.UI;
using Asteroids.Gameplay;

namespace Asteroids.Core
{
    /// <summary>
    /// Game state manager managing lives, score tracking, player respawning,
    /// particle explosion triggers, and Game Over sequences.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Scene References")]
        [SerializeField] private Player player;
        [SerializeField] private ParticleSystem explosionEffect;
        [SerializeField] private GameObject gameOverUI;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text livesText;

        private int score;
        private int lives;

        public int Score => score;
        public int Lives => lives;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            NewGame();
        }

        private void Update()
        {
            if (lives <= 0 && Input.GetKeyDown(KeyCode.Return))
            {
                NewGame();
            }
        }

        public void NewGame()
        {
            Asteroid[] asteroids = FindObjectsOfType<Asteroid>();

            for (int i = 0; i < asteroids.Length; i++)
            {
                if (asteroids[i] != null)
                {
                    Destroy(asteroids[i].gameObject);
                }
            }

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(false);
            }

            SetScore(0);
            SetLives(Constants.DEFAULT_INITIAL_LIVES);
            Respawn();
        }

        private void SetScore(int score)
        {
            this.score = score;
            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }

        private void SetLives(int lives)
        {
            this.lives = lives;
            if (livesText != null)
            {
                livesText.text = lives.ToString();
            }
        }

        private void Respawn()
        {
            if (player != null)
            {
                player.transform.position = Vector3.zero;
                player.gameObject.SetActive(true);
            }
        }

        public void OnAsteroidDestroyed(Asteroid asteroid)
        {
            if (asteroid == null) return;

            if (explosionEffect != null)
            {
                explosionEffect.transform.position = asteroid.transform.position;
                explosionEffect.Play();
            }

            if (asteroid.Size < 0.7f)
            {
                SetScore(score + Constants.SCORE_SMALL_ASTEROID);
            }
            else if (asteroid.Size < 1.4f)
            {
                SetScore(score + Constants.SCORE_MEDIUM_ASTEROID);
            }
            else
            {
                SetScore(score + Constants.SCORE_LARGE_ASTEROID);
            }
        }

        public void OnPlayerDeath(Player player)
        {
            if (player == null) return;

            player.gameObject.SetActive(false);

            if (explosionEffect != null)
            {
                explosionEffect.transform.position = player.transform.position;
                explosionEffect.Play();
            }

            SetLives(lives - 1);

            if (lives <= 0)
            {
                if (gameOverUI != null)
                {
                    gameOverUI.SetActive(true);
                }
            }
            else
            {
                Invoke(nameof(Respawn), player.RespawnDelay);
            }
        }
    }
}
