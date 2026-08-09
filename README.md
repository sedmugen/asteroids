# Asteroids

> A classic 2D arcade game built with Unity 2023 and C# featuring physics-driven movement, procedural asteroid splitting, and responsive arcade scoring systems.

---

## 📷 Gameplay Preview

| Gameplay Action | Visual Preview |
| :--- | :--- |
| **Spaceship Movement & Firing** | ![Gameplay Demo](assets/gifs/demo.gif) |
| **Asteroid Fracturing & UI** | ![Gameplay Screenshot](assets/images/gameplay.png) |

*(Note: High-resolution media assets available in the [`assets/`](assets/) directory.)*

---

## 💡 Overview & Motivation

**Asteroids** is a modernized 2D recreation of the classic 1979 Atari arcade game. The player controls a triangular spaceship navigating an obstacle-filled 2D space, destroying incoming asteroids while avoiding collisions.

This project was built to demonstrate core game development fundamentals:
* **Rigid-body Physics:** Using force vectors and torque for realistic inertial spaceship mechanics.
* **Procedural Object Lifecycles:** Perimeter-based spawner logic and procedural splitting of parent game objects into dynamic children.
* **Toroidal Screen Topology:** World-space camera boundary calculations allowing seamless screen wrapping.
* **State & Life Management:** Event-driven Singleton pattern governing lives, score tracking, invulnerability layers, and game over states.

---

## ✨ Features

* **Physics-Driven Flight:** Thrust (`AddForce`) and rotational torque (`AddTorque`) creating classic zero-gravity arcade physics.
* **Toroidal Screen Wrapping:** Smoothly teleports the player ship across opposing screen boundaries without physics velocity interruption.
* **Procedural Asteroid Fracturing:** Asteroids split into two smaller sub-asteroids upon hit, scaling mass, size, and speed dynamically.
* **Perimeter Spawning Engine:** Spawns asteroids around screen perimeters with random trajectory angles towards the playable screen area.
* **Weapon Rate-of-Fire Control:** Firing system with cooldown timers and automatic bullet lifecycle cleanup.
* **Invulnerability System:** Temporary collision layer suppression upon respawn to ensure safe gameplay entry.
* **Arcade UI & Explosions:** Score counter, life counter, particle explosion effects, and Enter-key instant game restart flow.

---

## 🛠️ Tech Stack

* **Game Engine:** Unity `2023.1.20f1` (2D Physics & Sprite Pipeline)
* **Language:** C# (.NET / Mono)
* **Physics Engine:** Unity 2D Physics Engine (`Rigidbody2D`, `BoxCollider2D`, `CircleCollider2D`, `LayerMask`)
* **UI & Rendering:** Unity UI (`UnityEngine.UI`), Particle System (`ParticleSystem`), Vector Fonts

---

## 📐 Architecture Overview

```
                               +-------------------+
                               |  GameManager      |
                               |  (Singleton)      |
                               +---------+---------+
                                         |
            +----------------------------+----------------------------+
            |                            |                            |
            v                            v                            v
   +-----------------+          +------------------+         +-----------------+
   |  Player         |          | AsteroidSpawner  |         | UI & Effects    |
   |  - Movement     |          | - Spawns prefabs |         | - Score / Lives |
   |  - Firing Limit |          +--------+---------+         | - Explosion PS  |
   |  - Screen Wrap  |                   |                   +-----------------+
   +--------+--------+                   v
            |                   +------------------+
            v                   | Asteroid         |
   +-----------------+          | - Mass / Sizing  |
   | Bullet          |          | - Dynamic Split  |
   +-----------------+          +------------------+
```

For detailed architectural breakdown, see [`docs/architecture.md`](docs/architecture.md).  
For component API references, see [`docs/api.md`](docs/api.md).  
For architectural decision records, see [`docs/decisions.md`](docs/decisions.md).

---

## ⚙️ Installation & Building

### Prerequisites
* **Unity Engine:** Version `2023.1.20f1` (or compatible 2023.x release) with 2D Build Support.
* **Git LFS:** Required if fetching large binary textures or audio files.

### Cloning & Opening Project
```bash
git clone https://github.com/sedmugen/asteroids.git
```
1. Launch **Unity Hub**.
2. Click **Add** -> **Add project from disk** and select the cloned `asteroids` directory.
3. Open project using Unity `2023.1.20f1`.
4. Open the main gameplay scene: `Assets/Scenes/Asteroids.unity`.

### Building Standalone Executable (Windows / macOS / Linux)
1. In Unity Editor, open **File -> Build Settings**.
2. Ensure `Assets/Scenes/Asteroids.unity` is included in **Scenes In Build**.
3. Select your target platform and click **Build**.

---

## 🎮 Controls & Usage

| Input Action | Primary Key | Secondary Input |
| :--- | :--- | :--- |
| **Thrust Forward** | `W` | `Up Arrow` |
| **Rotate Left** | `A` | `Left Arrow` |
| **Rotate Right** | `D` | `Right Arrow` |
| **Shoot Laser** | `Space` | `Left Mouse Click` |
| **Restart Game** | `Enter / Return` | — |

---

## 🗺️ Roadmap

- [x] Physics-based flight & rotational torque controls
- [x] Toroidal screen wrapping system
- [x] Dynamic asteroid splitting and perimeter spawner
- [x] Score, lives counter, and game over state machine
- [ ] Upgrade legacy UI text to TextMeshPro (`TMPro.TextMeshProUGUI`)
- [ ] Object pooling manager for `Bullet` and `Asteroid` game objects
- [ ] Sound effects (laser shoot, engine thrust, explosions, ambient music)
- [ ] Controller input integration via Unity Input System (`com.unity.inputsystem`)

---

## 📄 License

This project is licensed under the MIT License — see the [`LICENSE`](LICENSE) file for details.
