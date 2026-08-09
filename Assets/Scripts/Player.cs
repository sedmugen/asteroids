using UnityEngine;
using Asteroids.Core;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Player controller handling physics-based flight, steering, weapon firing,
    /// screen wrapping bounds, and collision response.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;

        [Header("Weapon Configuration")]
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private float fireRate = Constants.DEFAULT_FIRE_RATE;
        private float nextFireTime;

        [Header("Flight Dynamics")]
        [SerializeField] private float thrustSpeed = 1f;
        [SerializeField] private float rotationSpeed = 0.1f;

        [Header("Lifecycle & Invulnerability")]
        [SerializeField] private float respawnDelay = 3f;
        [SerializeField] private float respawnInvulnerability = 3f;

        [Header("Screen Wrapping")]
        [SerializeField] private bool screenWrapping = true;
        private Bounds screenBounds;

        private bool thrusting;
        private float turnDirection;
        private int playerLayer;
        private int ignoreCollisionsLayer;

        public bool IsThrusting => thrusting;
        public float RespawnDelay => respawnDelay;
        public float RespawnInvulnerability => respawnInvulnerability;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            playerLayer = LayerMask.NameToLayer(Constants.LAYER_PLAYER);
            ignoreCollisionsLayer = LayerMask.NameToLayer(Constants.LAYER_IGNORE_COLLISIONS);
        }

        private void Start()
        {
            GameObject[] boundaries = GameObject.FindGameObjectsWithTag(Constants.TAG_BOUNDARY);

            for (int i = 0; i < boundaries.Length; i++)
            {
                boundaries[i].SetActive(!screenWrapping);
            }

            UpdateScreenBounds();
        }

        private void OnEnable()
        {
            TurnOffCollisions();
            Invoke(nameof(TurnOnCollisions), respawnInvulnerability);
        }

        private void Update()
        {
            thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                turnDirection = 1f;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                turnDirection = -1f;
            }
            else
            {
                turnDirection = 0f;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time >= nextFireTime)
            {
                Shoot();
            }
        }

        private void FixedUpdate()
        {
            if (thrusting)
            {
                rb.AddForce(transform.up * thrustSpeed);
            }

            if (turnDirection != 0f)
            {
                rb.AddTorque(rotationSpeed * turnDirection);
            }

            if (screenWrapping)
            {
                ScreenWrap();
            }
        }

        private void UpdateScreenBounds()
        {
            if (Camera.main == null) return;

            screenBounds = new Bounds();
            screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(Vector3.zero));
            screenBounds.Encapsulate(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f)));
        }

        private void ScreenWrap()
        {
            if (rb.position.x > screenBounds.max.x + 0.5f)
            {
                rb.position = new Vector2(screenBounds.min.x - 0.5f, rb.position.y);
            }
            else if (rb.position.x < screenBounds.min.x - 0.5f)
            {
                rb.position = new Vector2(screenBounds.max.x + 0.5f, rb.position.y);
            }
            else if (rb.position.y > screenBounds.max.y + 0.5f)
            {
                rb.position = new Vector2(rb.position.x, screenBounds.min.y - 0.5f);
            }
            else if (rb.position.y < screenBounds.min.y - 0.5f)
            {
                rb.position = new Vector2(rb.position.x, screenBounds.max.y + 0.5f);
            }
        }

        private void Shoot()
        {
            nextFireTime = Time.time + fireRate;
            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.Shoot(transform.up);
        }

        private void TurnOffCollisions()
        {
            gameObject.layer = ignoreCollisionsLayer != -1 ? ignoreCollisionsLayer : LayerMask.NameToLayer(Constants.LAYER_IGNORE_COLLISIONS);
        }

        private void TurnOnCollisions()
        {
            gameObject.layer = playerLayer != -1 ? playerLayer : LayerMask.NameToLayer(Constants.LAYER_PLAYER);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.TAG_ASTEROID))
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0f;

                GameManager.Instance.OnPlayerDeath(this);
            }
        }
    }
}
