using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;


[Serializable]
public class GameData
{
    public Vector3 playerPosition;

}

public class SaveLoadManager : MonoBehaviour
{
    private static SaveLoadManager instance;

    public static SaveLoadManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveLoadManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SaveLoadManager");
                    instance = singletonObject.AddComponent<SaveLoadManager>();
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }


    public Vector3 loadedPosition;
    public bool hasLoadedGame = false;

    private const string PlayerPosXKey = "PlayerPosX";
    private const string PlayerPosYKey = "PlayerPosY";
    private const string PlayerPosZKey = "PlayerPosZ";
    private const string HasSavedGameKey = "HasSavedGame";

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("SaveLoadManager initialized.");
    }

    void Start()
    {
         LoadGameDataFromFile();

    }

    public void ApplyLoadedData()
    {
        if (!hasLoadedGame)
        {
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Cannot apply loaded data: Player object not found! Make sure your player has the tag 'Player'.");
            return;
        }

        player.transform.position = loadedPosition;

        Debug.Log("Loaded game data (position) applied to player.");

        hasLoadedGame = false;
    }

    public void SaveGame()
    {
        Debug.Log("SaveGame started (PlayerPrefs).");

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Cannot save game: Player object not found (Tag 'Player')!");
            return;
        }
        Debug.Log("Player object found.");

        PlayerPrefs.SetFloat(PlayerPosXKey, player.transform.position.x);
        PlayerPrefs.SetFloat(PlayerPosYKey, player.transform.position.y);
        PlayerPrefs.SetFloat(PlayerPosZKey, player.transform.position.z);

        PlayerPrefs.SetInt(HasSavedGameKey, 1);

        PlayerPrefs.Save();

        Debug.Log("Game saved successfully (PlayerPrefs).");
    }

    public void LoadGameDataFromFile()
    {
        Debug.Log("LoadGameDataFromFile started (PlayerPrefs).");

        if (!PlayerPrefs.HasKey(HasSavedGameKey) || PlayerPrefs.GetInt(HasSavedGameKey) == 0)
        {
            Debug.LogWarning("No save data found in PlayerPrefs.");
            hasLoadedGame = false;
            return;
        }

        float x = PlayerPrefs.GetFloat(PlayerPosXKey, 0f);
        float y = PlayerPrefs.GetFloat(PlayerPosYKey, 0f);
        float z = PlayerPrefs.GetFloat(PlayerPosZKey, 0f);

        loadedPosition = new Vector3(x, y, z);

        hasLoadedGame = true;
        Debug.Log("Game data loaded into memory from PlayerPrefs. Position: " + loadedPosition);
    }

     public void SaveAndQuit()
     {
         Debug.Log("SaveAndQuit started.");
         SaveGame();

         Debug.Log("Saving game. Quitting application...");


         Debug.Log("Attempting to quit application.");
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
     }

     public void QuitGame()
     {
         Debug.Log("Quitting game...");
         #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #else
         Application.Quit();
         #endif
     }

     public void DeleteSavedGame()
     {
         PlayerPrefs.DeleteKey(PlayerPosXKey);
         PlayerPrefs.DeleteKey(PlayerPosYKey);
         PlayerPrefs.DeleteKey(PlayerPosZKey);
         PlayerPrefs.DeleteKey(HasSavedGameKey);
         PlayerPrefs.Save();
         hasLoadedGame = false;
         loadedPosition = Vector3.zero;
         Debug.Log("Saved game data deleted from PlayerPrefs.");
     }
}