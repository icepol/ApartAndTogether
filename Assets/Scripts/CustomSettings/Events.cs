namespace pixelook
{
    public static class Events
    {
        // level progression events
        public const string PLAYER_INITIATED = "PlayerInitiated";
        public const string GAME_STARTED = "GameStarted";
        public const string GAME_FINISHED = "GameFinished";
        public const string GAME_OVER = "GameOver";
        public const string PLAYER_DIED = "PlayerDied";
        
        public const string ENEMY_SPAWNED = "EnemySpawned";
        public const string ENEMY_DIED = "EnemyDied";
        public const string ENEMY_COLLISION = "EnemyCollision";
        
        public const string LIVES_COUNT_CHANGED = "LivesCountChanged";
        public const string SCORE_CHANGED = "ScoreChanged";
        
        public const string MOVEMENT_CHANGED = "MovementChanged";

        // settings events
        public const string MUSIC_SETTINGS_CHANGED = "MusicSettingsChanged";

        public const string LEAF_ACTIVATED = "LeafActivated";
        public const string LEAF_FAILED = "LeafFailed";
        public const string LEAF_COLLECTED = "LeafCollected";
    }
}