# User & Gameplay Guide

This guide details the controls, scoring mechanics, entity behaviors, and game loop flow of **Asteroids 2D**.

---

## 🕹️ Controls & Input Scheme

The game supports standard keyboard and mouse inputs:

| Action | Key Assignment | Description |
| :--- | :--- | :--- |
| **Thrust Forward** | `W` / `Up Arrow` | Applies forward force (`AddForce`) along ship's local Y-axis |
| **Rotate Left** | `A` / `Left Arrow` | Imparts counter-clockwise rotational torque (`AddTorque`) |
| **Rotate Right** | `D` / `Right Arrow` | Imparts clockwise rotational torque (`AddTorque`) |
| **Fire Laser** | `Space` / `Left Click` | Instantiates a bullet projectile aligned with ship heading |
| **Restart Game** | `Enter / Return` | Resets score, lives, and spawns new game upon Game Over |

---

## 🎯 Gameplay Mechanics

### 1. Spaceship Physics & Inertia
The player ship operates in zero gravity (`Gravity Scale = 0`).
* **Forward Accelerating:** Holding `W` adds continuous linear force. When released, momentum persists due to zero linear drag.
* **Rotational Steering:** Pressing `A` or `D` applies angular torque.
* **Screen Wrapping Boundary:** When ship position exceeds camera bounds (`screenBounds.max` / `screenBounds.min`), position wraps seamlessly to the opposite side of the screen without interrupting velocity.

### 2. Asteroid Sizing & Fracturing
Asteroids spawn along screen perimeters with random rotational variances.
* **Large Asteroid:** Slow moving, high physics mass (`size ≈ 1.5f`). Upon hit, splits into two Medium Asteroids and awards **+25 points**.
* **Medium Asteroid:** Moderate speed and mass (`size ≈ 0.75f`). Upon hit, splits into two Small Asteroids and awards **+50 points**.
* **Small Asteroid:** High speed, low mass (`size < 0.7f`). Below minimum split threshold (`minSize = 0.35f`); upon hit, completely destroyed and awards **+100 points**.

### 3. Lives & Invulnerability
* **Starting Lives:** Player starts with `3` lives.
* **Collision Death:** Colliding with an asteroid destroys the ship and triggers an explosion particle effect.
* **Post-Respawn Invulnerability:** Upon respawning, player layer is switched to `"Ignore Collisions"` for `3.0` seconds to ensure safe maneuvering away from asteroids.

### 4. Game Over & Restart
When remaining lives drop to `0`:
* Game Over UI overlay becomes active.
* Pressing `Enter / Return` destroys remaining asteroids, resets score to `0`, restores `3` lives, and initiates a clean game loop.
