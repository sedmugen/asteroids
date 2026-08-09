# Component API Reference

This document provides API documentation for the C# scripts in `Assets/Scripts/`.

---

## `Asteroids.Core.Constants`

Static utility class providing centralized string constants, physics layer names, scoring values, and game balance defaults.

### Constants
* `public const string TAG_BULLET = "Bullet"` — Inspector tag for bullet prefabs.
* `public const string TAG_ASTEROID = "Asteroid"` — Inspector tag for asteroid prefabs.
* `public const string TAG_BOUNDARY = "Boundary"` — Inspector tag for optional screen boundary objects.
* `public const string LAYER_PLAYER = "Player"` — Physics layer for normal player collisions.
* `public const string LAYER_IGNORE_COLLISIONS = "Ignore Collisions"` — Physics layer during respawn invulnerability.
* `public const int SCORE_SMALL_ASTEROID = 100` — Score granted for destroying a small asteroid.
* `public const int SCORE_MEDIUM_ASTEROID = 50` — Score granted for destroying a medium asteroid.
* `public const int SCORE_LARGE_ASTEROID = 25` — Score granted for destroying a large asteroid.
* `public const int DEFAULT_INITIAL_LIVES = 3` — Initial lives granted upon game start.
* `public const float DEFAULT_FIRE_RATE = 0.2f` — Default weapon firing rate cooldown in seconds.

---

## `Asteroids.Core.GameManager`

Inherits from `MonoBehaviour`. Implements Singleton pattern.

### Properties
* `public static GameManager Instance { get; private set; }` — Global singleton access point.
* `public int Score { get; }` — Current game score.
* `public int Lives { get; }` — Current remaining player lives.

### Methods
* `public void NewGame()` — Destroys active scene asteroids, resets score to 0, restores initial lives, and respawns ship.
* `public void OnAsteroidDestroyed(Asteroid asteroid)` — Plays explosion particle effect and increments score based on asteroid size tier.
* `public void OnPlayerDeath(Player player)` — Deactivates player object, triggers particle effect, decrements life counter, and schedules respawn or Game Over sequence.

---

## `Asteroids.Gameplay.Player`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D`.

### Serialized Fields
* `[SerializeField] private Bullet bulletPrefab` — Reference to bullet prefab.
* `[SerializeField] private float fireRate = 0.2f` — Minimum delay between consecutive shots in seconds.
* `[SerializeField] private float thrustSpeed = 1f` — Forward acceleration force multiplier.
* `[SerializeField] private float rotationSpeed = 0.1f` — Torque rotation multiplier.
* `[SerializeField] private float respawnDelay = 3f` — Delay in seconds before player respawns after death.
* `[SerializeField] private float respawnInvulnerability = 3f` — Invulnerability duration upon respawn.
* `[SerializeField] private bool screenWrapping = true` — Enables toroidal screen boundary wrapping.

### Properties
* `public bool IsThrusting { get; }` — Indicates whether thrust input is active.
* `public float RespawnDelay { get; }` — Gets the configured respawn delay.
* `public float RespawnInvulnerability { get; }` — Gets the configured invulnerability period.

---

## `Asteroids.Gameplay.Asteroid`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D` and `SpriteRenderer`.

### Serialized Fields
* `[SerializeField] private Sprite[] sprites` — Array of visual sprite variants.
* `[SerializeField] private float size = 1f` — Dynamic scale factor of the asteroid.
* `[SerializeField] private float minSize = 0.35f` — Threshold below which splitting does not occur.
* `[SerializeField] private float maxSize = 1.65f` — Maximum size for newly spawned primary asteroids.
* `[SerializeField] private float movementSpeed = 50f` — Initial impulse force magnitude.
* `[SerializeField] private float maxLifetime = 30f` — Lifespan before automatic destruction.

### Properties
* `public float Size { get; set; }` — Scale factor of the asteroid.
* `public float MinSize { get; }` — Minimum size threshold for splitting.
* `public float MaxSize { get; }` — Maximum size threshold.
* `public float MovementSpeed { get; }` — Impulse force magnitude.

### Methods
* `public void SetTrajectory(Vector2 direction)` — Applies impulse force vector in specified direction.

---

## `Asteroids.Gameplay.AsteroidSpawner`

Inherits from `MonoBehaviour`.

### Serialized Fields
* `[SerializeField] private Asteroid asteroidPrefab` — Reference to asteroid prefab.
* `[SerializeField] private float spawnDistance = 12f` — Distance from origin where asteroids spawn.
* `[SerializeField] private float spawnRate = 1f` — Interval in seconds between spawn batches.
* `[SerializeField] private int amountPerSpawn = 1` — Number of asteroids spawned per cycle.
* `[SerializeField] private float trajectoryVariance = 15f` — Maximum angular trajectory variance in degrees.

### Methods
* `public void Spawn()` — Instantiates asteroids around screen perimeter with trajectory variance.

---

## `Asteroids.Gameplay.Bullet`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D`.

### Serialized Fields
* `[SerializeField] private float speed = 500f` — Impulse velocity.
* `[SerializeField] private float maxLifetime = 10f` — Lifespan before automatic destruction.

### Properties
* `public float Speed { get; }` — Impulse velocity.
* `public float MaxLifetime { get; }` — Lifespan before destruction.

### Methods
* `public void Shoot(Vector2 direction)` — Imparts directional force vector and sets destruction timer.
