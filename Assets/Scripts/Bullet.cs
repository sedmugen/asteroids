using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Bullet projectile component applying impulse force and handling collision destruction.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D rb;

        [SerializeField] private float speed = 500f;
        [SerializeField] private float maxLifetime = 10f;

        public float Speed => speed;
        public float MaxLifetime => maxLifetime;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Shoot(Vector2 direction)
        {
            rb.AddForce(direction * speed);
            Destroy(gameObject, maxLifetime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
