using UnityEngine;
using Asteroids.Core;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Asteroid controller handling random sprite assignment, physics scaling,
    /// dynamic splitting on hit, and score trigger events.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float size = 1f;
        [SerializeField] private float minSize = 0.35f;
        [SerializeField] private float maxSize = 1.65f;
        [SerializeField] private float movementSpeed = 50f;
        [SerializeField] private float maxLifetime = 30f;

        public float Size
        {
            get => size;
            set => size = value;
        }

        public float MinSize => minSize;
        public float MaxSize => maxSize;
        public float MovementSpeed => movementSpeed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            if (sprites != null && sprites.Length > 0)
            {
                spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            }

            transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);
            transform.localScale = Vector3.one * size;
            rb.mass = size;

            Destroy(gameObject, maxLifetime);
        }

        public void SetTrajectory(Vector2 direction)
        {
            rb.AddForce(direction * movementSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag(Constants.TAG_BULLET))
            {
                if ((size * 0.5f) >= minSize)
                {
                    CreateSplit();
                    CreateSplit();
                }

                GameManager.Instance.OnAsteroidDestroyed(this);
                Destroy(gameObject);
            }
        }

        private Asteroid CreateSplit()
        {
            Vector2 position = transform.position;
            position += Random.insideUnitCircle * 0.5f;

            Asteroid half = Instantiate(this, position, transform.rotation);
            half.Size = size * 0.5f;
            half.SetTrajectory(Random.insideUnitCircle.normalized);

            return half;
        }
    }
}
