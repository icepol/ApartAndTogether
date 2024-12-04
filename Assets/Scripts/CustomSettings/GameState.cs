namespace pixelook
{
    public static class GameState
    {
        private static int _level;
        private static int _score;
        private static int _bonusScore;
        private static int _lives;

        public static bool IsGameRunning { get; set; }
        public static bool IsGameOver { get; set; }

        public static int Score
        {
            get => _score;
            
            set
            {
                if (_score == value)
                    return;
                
                _score = value;
                
                 EventManager.TriggerEvent(Events.SCORE_CHANGED);
            }
        }

        public static int Lives
        {
            get => _lives;
            
            set
            {
                _lives = value;
                
                EventManager.TriggerEvent(Events.LIVES_COUNT_CHANGED);

                if (_lives == 0)
                    EventManager.TriggerEvent(Events.GAME_OVER);
            }
        }
        
        public static int CollectedCount { get; set; }
        
        public static void OnApplicationStarted()
        {
            Lives = 3;
            Score = 0;
            CollectedCount = 0;
            IsGameRunning = false;
            IsGameOver = false;
        }

        public static void OnGameStarted()
        {
            Score = 0;
            Lives = 3;
            CollectedCount = 0;
            IsGameRunning = true;
            IsGameOver = false;
        }
    }
}