# Testing & Quality Assurance Guide

This document details automated build verification and manual testing protocols for **Asteroids 2D**.

---

## 🧪 Automated CI Checks

A GitHub Actions workflow is configured in [`.github/workflows/ci.yml`](../.github/workflows/ci.yml) to validate repository integrity on every push to `main` and pull request submission.

Automated checks include:
* **Structural Verification:** Confirms presence of mandatory open-source files (`README.md`, `LICENSE`, `CHANGELOG.md`, `CONTRIBUTING.md`, `Packages/manifest.json`, `ProjectSettings/ProjectVersion.txt`).
* **C# File Audit:** Scans C# script syntax across `Assets/Scripts/`.

---

## 📋 Manual Testing Protocol

Execute the following verification checklist in Unity Editor before submitting pull requests:

### 1. Spaceship Flight Mechanics
* [ ] Holding `W` adds forward acceleration along ship's local heading.
* [ ] Releasing `W` maintains velocity due to zero linear drag.
* [ ] Pressing `A` / `D` rotates ship counter-clockwise / clockwise.
* [ ] Exceeding top, bottom, left, or right screen edges teleports ship smoothly to opposing boundary.

### 2. Weapon Firing & Rate Limit
* [ ] Pressing `Space` fires a bullet aligned with ship heading.
* [ ] Rapidly tapping `Space` respects the `fireRate` timer (`0.2s` cooldown) and does not spawn overlapping bullet streams.
* [ ] Bullets self-destruct after reaching maximum lifetime (`10s`) or upon collision.

### 3. Asteroid Fracturing & Spawner
* [ ] Primary asteroids spawn continuously around perimeter screen radius.
* [ ] Shooting a Large Asteroid breaks it into two Medium Asteroids (+25 score).
* [ ] Shooting a Medium Asteroid breaks it into two Small Asteroids (+50 score).
* [ ] Shooting a Small Asteroid destroys it completely (+100 score).

### 4. Player Death & Respawn
* [ ] Collision with an asteroid destroys ship and triggers particle explosion.
* [ ] Life counter decrements by 1.
* [ ] Ship respawns at `(0, 0, 0)` with temporary invulnerability layer (`3s`).
* [ ] Reaching 0 lives displays Game Over screen.
* [ ] Pressing `Enter` triggers `NewGame()`, clearing asteroids and resetting score/lives.
