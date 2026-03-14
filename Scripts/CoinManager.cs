using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    public Text coinText;
    private int coinCount = 0;

    public GameObject achievementNotification;
    public int achievementThreshold = 10;
    public float achievementDisplayTime = 3.0f;
    private bool achievementUnlocked = false;

    public AudioClip achievementSound;
    private AudioSource audioSource;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("Na GameManageru chybí komponenta AudioSource!");
        }

        if (achievementNotification != null)
        {
            achievementNotification.SetActive(false);
        }
        else
        {
            Debug.LogError("Achievement Notification není přiřazen v GameManageru!");
        }
    }

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateCoinText();

        if (!achievementUnlocked && coinCount >= achievementThreshold)
        {
            ShowAchievement();
            achievementUnlocked = true;
        }
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins : " + coinCount.ToString();
        }
        else
        {
            Debug.LogError("Coin Text není přiřazen v GameManageru!");
        }
    }

    void ShowAchievement()
    {
        if (achievementNotification != null)
        {
            StartCoroutine(ShowAchievementCoroutine());
        }
    }

    IEnumerator ShowAchievementCoroutine()
    {
        if (audioSource != null && achievementSound != null)
        {
            audioSource.PlayOneShot(achievementSound);
        }
        else if (achievementSound == null)
        {
            Debug.LogWarning("Achievement Sound není nastaven v GameManageru!");
        }

        Debug.Log("Achievement Unlocked: Dosáhl jsi " + achievementThreshold + " mincí!");
        achievementNotification.SetActive(true);
        yield return new WaitForSeconds(achievementDisplayTime);
        achievementNotification.SetActive(false);
    }
}