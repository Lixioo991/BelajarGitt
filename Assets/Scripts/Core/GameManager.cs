using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetState(GameState.MainMenu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
                PauseGame();
            else if (currentState == GameState.Paused)
                ResumeGame();
        }
    }

    public void SetState(GameState newState)
    {
        currentState = newState;

        // matikan semua UI dulu
        if (mainMenuUI != null) mainMenuUI.SetActive(false);
        if (pauseUI != null) pauseUI.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(false);

        switch (newState)
        {
            case GameState.MainMenu:
                if (mainMenuUI != null) mainMenuUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case GameState.Playing:
                Time.timeScale = 1f;
                break;

            case GameState.Paused:
                if (pauseUI != null) pauseUI.SetActive(true);
                Time.timeScale = 0f;
                break;

            case GameState.GameOver:
                if (gameOverUI != null) gameOverUI.SetActive(true);
                Time.timeScale = 0f;
                break;
        }
    }

    public void StartGame()
    {
        SetState(GameState.Playing);
    }

    public void PauseGame()
    {
        SetState(GameState.Paused);
    }

    public void ResumeGame()
    {
        SetState(GameState.Playing);
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SetState(GameState.MainMenu);
    }
}