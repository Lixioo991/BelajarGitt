using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenuUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject gameOverUI;

    void Start()
    {
        ShowMainMenu();
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void ShowPause()
    {
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(true);
        gameOverUI.SetActive(false);
    }

    public void Resume()
    {
        GameManager.Instance.ResumeGame();
        ShowMainMenu(); // atau hide semua
    }

    public void ShowGameOver()
    {
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        GameManager.Instance.RestartGame();
    }

    public void Menu()
    {
        GameManager.Instance.BackToMenu();
    }
}