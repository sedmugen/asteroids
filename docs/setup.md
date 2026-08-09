# Setup & Installation Guide

This document provides instructions for setting up the development environment, importing the **Asteroids** project into Unity, and launching the game.

---

## 📋 Prerequisites

### Required Software
* **Unity Hub:** [Version 3.0 or later](https://unity.com/download)
* **Unity Engine:** Version `2023.1.20f1` (installed via Unity Hub with 2D Build Support)
* **Git:** [Version 2.30 or later](https://git-scm.com/)

### Hardware Requirements
* **OS:** Windows 10/11 (x64), macOS 11.0+, or Linux (Ubuntu 20.04+)
* **GPU:** Graphics card with DX10, DX11, or Metal capability
* **RAM:** Minimum 8 GB (16 GB recommended)

---

## 🛠️ Step-by-Step Installation

### Step 1: Clone the Repository
Clone the project repository to your local workstation:

```bash
git clone https://github.com/sedmugen/asteroids.git
cd asteroids
```

### Step 2: Open Project in Unity Hub
1. Launch **Unity Hub**.
2. Click **Projects** -> **Add** -> **Add project from disk**.
3. Navigate to the directory where you cloned `asteroids` and click **Add Project**.
4. Verify that Unity Editor version `2023.1.20f1` is selected. If prompt appears to install missing editor modules, download `Unity 2023.1.20f1` via Unity Hub.

### Step 3: Load Main Scene
1. Once the Unity Editor has initialized, locate the **Project** window in the bottom dock.
2. Navigate to `Assets/Scenes/Asteroids.unity`.
3. Double-click `Asteroids.unity` to open the primary gameplay scene.

### Step 4: Play in Editor
* Click the **Play** button (`Ctrl + P` / `Cmd + P`) at the top of the Unity Editor window to start the game.

---

## ❓ Troubleshooting & FAQs

### Missing Package Warnings
If Unity displays package resolution errors upon first open:
1. Go to **Window** -> **Package Manager**.
2. Click **Packages: In Project** -> **Reset to default packages**.
3. Re-import package manifest located at [`Packages/manifest.json`](../Packages/manifest.json).

### Compiler Errors on Project Load
If script compilation errors occur:
1. Ensure Unity Editor version matches `2023.1.20f1` exactly (check `ProjectSettings/ProjectVersion.txt`).
2. Select **Assets** -> **Reimport All** from the top menu to force C# assemblies rebuild.
