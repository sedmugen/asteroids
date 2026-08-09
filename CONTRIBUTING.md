# Contributing Guidelines

Thank you for your interest in contributing to **Asteroids**!

---

## 🚀 How to Contribute

1. **Fork the Repository:** Create your own fork of [`sedmugen/asteroids`](https://github.com/sedmugen/asteroids.git).
2. **Create a Feature Branch:** Branch out from `main` using standard naming conventions:
   ```bash
   git checkout -b <category>/<short-description>
   ```
   *Approved Categories:* `feature/`, `bugfix/`, `hotfix/`, `docs/`, `chore/`, `refactor/`, `test/`
3. **Make your changes:** Follow C# coding standards, encapsulate inspector fields with `[SerializeField] private`, and verify that Unity builds without errors or warnings.
4. **Commit using Conventional Commits:** (See specification below).
5. **Open a Pull Request:** Target `main` with a clear explanation of changes made.

---

## 📝 Commit Conventions

All commits must adhere to [Conventional Commits](https://www.conventionalcommits.org/):

```
<type>(optional-scope): description
```

### Approved Types
* `feat`: A new feature
* `fix`: A bug fix
* `docs`: Documentation changes only
* `style`: Formatting, missing semi-colons, etc. (no code change)
* `refactor`: Refactoring code without altering functionality
* `perf`: Performance improvements
* `test`: Adding or correcting tests
* `chore`: Build processes, package manager dependencies, or tooling

### Rules
* Write commit messages in the **imperative mood** (e.g. `feat: add weapon overheat effect`, NOT `feat: added weapon overheat effect`).
* Limit the first line to **72 characters**.
* One logical change per commit.
* Avoid non-descriptive messages like `update`, `changes`, `fix`, `asdf`.

---

## 💻 Code Style Guidelines

* **Namespaces:** Scope scripts under `Asteroids.Gameplay` or `Asteroids.Core`.
* **Field Encapsulation:** Prefer `[SerializeField] private` fields over public fields. Use public properties for read-only access.
* **String Allocation:** Avoid magic strings in `Update` loops; use centralized `Constants` or cached layer IDs.
* **Docstrings:** Use C# XML summary comments (`/// <summary>`) for public interfaces.
