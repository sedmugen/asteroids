using UnityEngine;

namespace Asteroids.Gameplay
{
    /// <summary>
    /// Spawner system generating asteroids around the screen perimeter at scheduled intervals.
    /// </summary>
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private Asteroid asteroidPrefab;
        [SerializeField] private float spawnDistance = 12f;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private int amountPerSpawn = 1;
        [Range(0f, 45f)]
        [SerializeField] private float trajectoryVariance = 15f;

        private float spawnTimer;

        private void Update()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnRate)
            {
                spawnTimer = 0f;
                Spawn();
            }
        }

        public void Spawn()
        {
            if (asteroidPrefab == null) return;

            for (int i = 0; i < amountPerSpawn; i++)
            {
                Vector3 spawnDirection = Random.insideUnitCircle.normalized;
                Vector3 spawnPoint = transform.position + (spawnDirection * spawnDistance);

                float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
                Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

                Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);
                asteroid.Size = Random.Range(asteroid.MinSize, asteroid.MaxSize);

                Vector2 trajectory = rotation * -spawnDirection;
                asteroid.SetTrajectory(trajectory);
            }
        }
    }
}
