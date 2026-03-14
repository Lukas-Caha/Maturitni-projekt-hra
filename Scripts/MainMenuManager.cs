using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button startGameButton;
    public string gameSceneName = "SampleScene";

    void Awake()
    {
        SaveLoadManager manager = SaveLoadManager.Instance;
        if (manager == null)
        {
        }
    }

    void Start()
    {
        SaveLoadManager.Instance.LoadGameDataFromFile();

        if (startGameButton != null)
        {
            startGameButton.onClick.AddListener(StartGame);
        }
        else
        {
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}