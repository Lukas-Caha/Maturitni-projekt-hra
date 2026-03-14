using UnityEngine;
using UnityEngine.UI;


public class NPCQuestGiver : MonoBehaviour
{
    public GameObject textBubbleCanvas;

    public Text textBubbleText;

    [TextArea] public string initialQuestText = "Hej, dones mi tenhle bazmek, prosim!";
    [TextArea] public string completionText = "Ty jo, díky moc! Jsi borec!";
    [TextArea] public string completedText = "Už jsi mi pomohl, díky.";

    public GameObject questItemInstance;

    public Image questItemUI;
    public Sprite questItemUISprite;


    private enum QuestState { NotStarted, Started, Completed }
    private QuestState currentState = QuestState.NotStarted;

    private PlayerInventory playerInventory;

    void Start()
    {
        if (textBubbleCanvas != null) textBubbleCanvas.SetActive(false);
        if (questItemInstance != null) questItemInstance.SetActive(false);

        if (questItemUI != null)
        {
            questItemUI.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory == null)
            {
                Debug.LogWarning("Hráč nemá skript PlayerInventory!", other.gameObject);
                return;
            }

            switch (currentState)
            {
                case QuestState.NotStarted:
                    ShowTextBubble(initialQuestText);
                    currentState = QuestState.Started;
                    if (questItemInstance != null)
                    {
                        questItemInstance.SetActive(true);
                    }
                    if (questItemUI != null && questItemUISprite != null)
                    {
                         questItemUI.enabled = true;
                         questItemUI.sprite = questItemUISprite;
                    }
                    break;

                case QuestState.Started:
                    if (playerInventory.HasQuestItem())
                    {
                        ShowTextBubble(completionText);
                        playerInventory.RemoveQuestItem();
                        currentState = QuestState.Completed;
                        if (questItemUI != null)
                        {
                           questItemUI.enabled = false;
                        }
                    }
                    else
                    {
                        ShowTextBubble(initialQuestText);
                    }
                    break;

                case QuestState.Completed:
                    if (!string.IsNullOrEmpty(completedText))
                    {
                        ShowTextBubble(completedText);
                    }
                    else
                    {
                        HideTextBubble();
                    }
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HideTextBubble();
        }
    }

    void ShowTextBubble(string textToShow)
    {
        if (textBubbleCanvas != null && textBubbleText != null)
        {
            textBubbleText.text = textToShow;

            textBubbleCanvas.SetActive(true);
        }
         else Debug.LogError("Text Bubble Canvas nebo Text komponenta není přiřazena v Inspectoru!");
    }

    void HideTextBubble()
    {
        if (textBubbleCanvas != null)
        {
            textBubbleCanvas.SetActive(false);
        }
    }
}