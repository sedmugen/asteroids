# Changelog

All notable changes to the **Asteroids** project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [1.0.0] - 2026-08-09

### Added
- Initial release of classic 2D Asteroids arcade game built in Unity 2023.
- Player spaceship mechanics with inertial thrust, rotation torque, and firing controls.
- Toroidal screen wrapping system mapping camera world space bounds.
- Dynamic asteroid splitting mechanics based on minimum size constraints.
- Perimeter asteroid spawner with trajectory variance angles.
- Game manager singleton handling lives, score, particle explosion effects, and game restart.
- Complete documentation suite including `README.md`, `architecture.md`, `api.md`, `decisions.md`, and MIT `LICENSE`.

### Changed
- Refactored field visibility across all C# scripts to use `[SerializeField] private` encapsulation.
- Extracted tag and layer string constants into centralized `Constants` class.
- Added weapon rate-of-fire cooldown timer to player controller.

---

## [0.9.0] - 2023-11-15

### Added
- Initial prototype scene setup and 2D physics rig.
- Basic player movement and asteroid spawner logic.
