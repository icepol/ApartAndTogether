using System.Collections;
using pixelook;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float restartLevelDelay = 5;

    public static GameManager Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;

        GameState.OnApplicationStarted();

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
    }

    private void OnEnable()
    {
        EventManager.AddListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.AddListener(Events.GAME_OVER, OnGameOver);
        EventManager.AddListener(Events.GAME_FINISHED, OnGameFinished);
    }
    
    private void OnDisable()
    {
        EventManager.RemoveListener(Events.GAME_STARTED, OnGameStarted);
        EventManager.RemoveListener(Events.GAME_OVER, OnGameOver);
        EventManager.RemoveListener(Events.GAME_FINISHED, OnGameFinished);
    }

    private void Update()
    {
        if (GameState.IsGameRunning) return;
        if (GameState.IsGameOver) return;

        if (!IsGameStarted()) return;
        
        EventManager.TriggerEvent(Events.GAME_STARTED);
    }

    private void OnGameStarted()
    {
        GameState.OnGameStarted();
    }

    private void OnGameOver()
    {
        GameState.IsGameRunning = false;
        GameState.IsGameOver = true;

        StartCoroutine(WaitAndRestart());
    }
    
    private void OnGameFinished()
    {
        GameState.IsGameRunning = false;
        GameState.IsGameOver = true;

        StartCoroutine(WaitAndRestart());
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(restartLevelDelay);
        
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    private bool IsGameStarted()
    {
        var isButtonPressed = Input.anyKeyDown;
        var isTouched = Input.GetMouseButtonDown(0) && Input.mousePosition.y < Screen.height * 0.5f;
        
        return isButtonPressed || isTouched;
    }
}
