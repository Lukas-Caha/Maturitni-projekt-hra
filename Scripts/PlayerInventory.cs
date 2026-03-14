using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasQuestItem = false;

    public void CollectQuestItem()
    {
        if (!hasQuestItem)
        {
            hasQuestItem = true;
            Debug.Log("Quest Item sebraný (stav inventáře aktualizován)!");
        }
    }

    public void RemoveQuestItem()
    {
        hasQuestItem = false;
        Debug.Log("Quest Item odevzdaný (stav inventáře aktualizován)!");
    }

    public bool HasQuestItem()
    {
        return hasQuestItem;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        QuestItem collectedItem = other.GetComponent<QuestItem>();

        if (collectedItem != null && !hasQuestItem)
        {
            CollectQuestItem();

            other.gameObject.SetActive(false);
        }
    }
}