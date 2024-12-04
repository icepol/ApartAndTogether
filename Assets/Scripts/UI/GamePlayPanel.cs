using pixelook;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _livesText;

    private void OnEnable()
    {
        EventManager.AddListener(Events.SCORE_CHANGED, OnScoreUpdated);
        EventManager.AddListener(Events.LIVES_COUNT_CHANGED, OnLivesUpdated);
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);        
    }

    private void Start()
    {
        _scoreText.text = GameState.Score.ToString();
        _livesText.text = "x " + GameState.Lives;
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.SCORE_CHANGED, OnScoreUpdated);
        EventManager.RemoveListener(Events.LIVES_COUNT_CHANGED, OnLivesUpdated);
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
    }

    private void OnScoreUpdated()
    {
        _scoreText.text = GameState.Score.ToString();
    }
    
    private void OnLivesUpdated()
    {
        _livesText.text = "x " + GameState.Lives;
    }

    private void OnGameStarted()
    {
        _scoreText.text = GameState.Score.ToString();
        _livesText.text = "x " + GameState.Lives;
    }
}
