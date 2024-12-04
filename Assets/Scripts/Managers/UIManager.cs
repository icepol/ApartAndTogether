using pixelook;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameFinishedPanel;
    [SerializeField] private GameObject gamePlayPanel;
    
    private void Awake()
    {
        DisableAll();
        
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.AddListener(Events.GAME_FINISHED, OnGameFinished);
        EventManager.AddListener(Events.GAME_OVER, OnGameOver);
    }

    private void Start()
    {
        mainPanel.SetActive(true);
    }
    
    private void OnDisable()
    {
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.RemoveListener(Events.GAME_FINISHED, OnGameFinished);
        EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
    }

    private void DisableAll()
    {
        mainPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameFinishedPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }

    private void OnGameStarted()
    {
        DisableAll();
        
        gamePlayPanel.SetActive(true);
    }
    
    private void OnGameOver()
    {
        DisableAll();
        
        gameOverPanel.SetActive(true);
    }
    
    private void OnGameFinished()
    {
        DisableAll();
        
        gameFinishedPanel.SetActive(true);
    }
}
