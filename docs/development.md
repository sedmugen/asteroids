# Developer & Build Guide

This guide provides technical specifications for developers modifying, extending, or building **Asteroids 2D**.

---

## 🏗️ Codebase Organization & Scoping

All gameplay scripts are located in `Assets/Scripts/` and organized into two core C# namespaces:

* **`Asteroids.Core`:** Infrastructure, constants, state management (`GameManager.cs`, `Constants.cs`).
* **`Asteroids.Gameplay`:** Entity physics, player input handling, and spawner logic (`Player.cs`, `Asteroid.cs`, `AsteroidSpawner.cs`, `Bullet.cs`).

### Field Encapsulation Rules
* All Unity Inspector fields must use `[SerializeField] private` visibility.
* Public read-only accessors use C# expression-bodied properties (e.g. `public int Score => score;`).
* Direct public fields are forbidden.

---

## ⚡ Command-Line Build Guide

You can generate standalone builds headlessly using Unity Batchmode commands.

### Building Windows 64-bit Executable
```powershell
& "C:\Program Files\Unity\Hub\Editor\2023.1.20f1\Editor\Unity.exe" `
  -batchmode `
  -quit `
  -projectPath "." `
  -buildTarget Win64 `
  -buildWindows64Player "Builds/Win64/Asteroids.exe"
```

### Building WebGL Executable
```powershell
& "C:\Program Files\Unity\Hub\Editor\2023.1.20f1\Editor\Unity.exe" `
  -batchmode `
  -quit `
  -projectPath "." `
  -buildTarget WebGL `
  -buildWebGLPlayer "Builds/WebGL"
```

---

## ⚙️ Package Management & Pruning

The package manifest [`Packages/manifest.json`](../Packages/manifest.json) has been streamlined for minimum disk footprint and fast import times.

Essential packages retained:
* `com.unity.2d.sprite` — 2D Sprite Rendering Pipeline
* `com.unity.modules.physics2d` — 2D Rigidbodies & Colliders
* `com.unity.ugui` — Legacy UI Engine
* `com.unity.textmeshpro` — TextMeshPro Engine
* `com.unity.modules.particlesystem` — Particle System Module

When adding new Unity packages, avoid importing unused heavy modules (VR, Vehicles, Terrain, Cloth, Wind).
