using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenuUI == null) return;

        bool isPaused = pauseMenuUI.activeSelf;
        pauseMenuUI.SetActive(!isPaused);

        if (!isPaused)
        {
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("Game Resumed");
        }
    }


    public void SaveAndExitGame()
    {
        Debug.Log("Save and Exit button clicked - Save/Quit functionality pending SaveLoadManager.");
    }
}