# Architecture Decision Records (ADR)

This document records key technical decisions made during the development and refactoring of **Asteroids**.

---

## ADR 001: 2D Rigidbody Physics vs Kinematic Transform Movement

### Status
Accepted

### Context
Asteroids requires inertial movement mechanics: the player ship accelerates when thrusting and continues coasting through zero-gravity space until counter-thrust is applied. Asteroids and bullets also travel along linear trajectory vectors.

### Decision
Use Unity's built-in 2D Physics engine (`Rigidbody2D` with `Gravity Scale = 0`) operating in `Dynamic` body mode.

### Consequences
* **Positive:** Free inertial motion simulation via `AddForce` and `AddTorque` without writing custom drag/velocity integration solvers. Built-in collision response via `OnCollisionEnter2D`.
* **Negative:** Screen wrapping must directly modify `rb.position` during `FixedUpdate` rather than updating `transform.position` to prevent physics engine desynchronization.

---

## ADR 002: Singleton State Manager for Lifecycle and Scoring

### Status
Accepted

### Context
Multiple game components (`Player`, `Asteroid`, `AsteroidSpawner`, `UI`) require shared access to scoring, life counters, respawn logic, and global particle effects.

### Decision
Implement `GameManager` as a static Singleton instance (`GameManager.Instance`) with `DontDestroyOnLoad`.

### Consequences
* **Positive:** Fast access point for core lifecycle events (`OnAsteroidDestroyed`, `OnPlayerDeath`).
* **Negative:** Global state access requires careful initialization order during scene reloads.

---

## ADR 003: Layer-Based Post-Spawn Invulnerability

### Status
Accepted

### Context
When the player respawns at origin `(0, 0, 0)`, spawned asteroids may be passing nearby, causing instant secondary deaths without player control agency.

### Decision
Dynamically switch the player GameObject's physics layer from `"Player"` to `"Ignore Collisions"` during respawn for a fixed invulnerability duration (`3` seconds), configured via Physics2D Collision Matrix settings.

### Consequences
* **Positive:** Simple, zero-cost collision suppression built into Unity's physics matrix without checking boolean flags inside `OnCollisionEnter2D`.
* **Negative:** Requires pre-configuring named collision layers in `TagManager.asset`.
