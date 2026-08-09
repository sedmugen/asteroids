namespace Asteroids.Core
{
    /// <summary>
    /// Centralized repository of string constants, tags, layers, and configuration values.
    /// </summary>
    public static class Constants
    {
        // Tags
        public const string TAG_BULLET = "Bullet";
        public const string TAG_ASTEROID = "Asteroid";
        public const string TAG_BOUNDARY = "Boundary";

        // Layers
        public const string LAYER_PLAYER = "Player";
        public const string LAYER_IGNORE_COLLISIONS = "Ignore Collisions";

        // Scoring
        public const int SCORE_SMALL_ASTEROID = 100;
        public const int SCORE_MEDIUM_ASTEROID = 50;
        public const int SCORE_LARGE_ASTEROID = 25;

        // Game Balance Defaults
        public const int DEFAULT_INITIAL_LIVES = 3;
        public const float DEFAULT_FIRE_RATE = 0.2f;
    }
}
