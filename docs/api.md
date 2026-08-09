# Component API Reference

This document provides API documentation for the C# scripts in `Assets/Scripts/`.

---

## `Asteroids.Core.GameManager`

Inherits from `MonoBehaviour`. Implements Singleton pattern.

### Properties
* `public static GameManager Instance { get; private set; }` — Global singleton access point.
* `public int Score { get; }` — Current game score.
* `public int Lives { get; }` — Current remaining player lives.

### Methods
* `public void OnAsteroidDestroyed(Asteroid asteroid)`
  Plays explosion particle system at asteroid position and increments score based on asteroid size tier.
* `public void OnPlayerDeath(Player player)`
  Deactivates player object, triggers particle effect, decrements life counter, and schedules respawn or game over screen.

---

## `Asteroids.Gameplay.Player`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D`.

### Serialized Fields
* `[SerializeField] private Bullet bulletPrefab` — Reference to bullet prefab.
* `[SerializeField] private float thrustSpeed = 1f` — Forward acceleration multiplier.
* `[SerializeField] private float rotationSpeed = 0.1f` — Torque rotation multiplier.
* `[SerializeField] private float fireRate = 0.25f` — Minimum delay between consecutive shots in seconds.
* `[SerializeField] private float respawnInvulnerability = 3f` — Invulnerability duration upon respawn.

### Properties
* `public bool IsThrusting { get; }` — Indicates whether thrust key is actively held down.

---

## `Asteroids.Gameplay.Asteroid`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D` and `SpriteRenderer`.

### Serialized Fields
* `[SerializeField] private Sprite[] sprites` — Array of visual sprite variants.
* `[SerializeField] private float size = 1f` — Dynamic scale factor of the asteroid.
* `[SerializeField] private float minSize = 0.35f` — Threshold below which splitting does not occur.
* `[SerializeField] private float maxSize = 1.65f` — Maximum size for newly spawned primary asteroids.
* `[SerializeField] private float movementSpeed = 50f` — Initial impulse force magnitude.
* `[SerializeField] private float maxLifetime = 30f` — Lifespan before automatic garbage destruction.

### Methods
* `public void SetTrajectory(Vector2 direction)` — Applies dynamic force vector to set direction.

---

## `Asteroids.Gameplay.AsteroidSpawner`

Inherits from `MonoBehaviour`.

### Serialized Fields
* `[SerializeField] private Asteroid asteroidPrefab` — Reference to asteroid prefab.
* `[SerializeField] private float spawnDistance = 12f` — Distance from origin where asteroids spawn.
* `[SerializeField] private float spawnRate = 1f` — Interval in seconds between spawn batches.
* `[SerializeField] private int amountPerSpawn = 1` — Number of asteroids spawned per cycle.

### Methods
* `public void Spawn()` — Instantiates asteroids around screen perimeter with trajectory variance.

---

## `Asteroids.Gameplay.Bullet`

Inherits from `MonoBehaviour`. Requires `Rigidbody2D`.

### Serialized Fields
* `[SerializeField] private float speed = 500f` — Impulse velocity.
* `[SerializeField] private float maxLifetime = 10f` — Lifespan before destruction.

### Methods
* `public void Shoot(Vector2 direction)` — Imparts directional force vector and sets destruction timer.
