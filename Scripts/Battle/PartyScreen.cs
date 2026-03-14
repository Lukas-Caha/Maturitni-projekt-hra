using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyScreen : MonoBehaviour
{
    [SerializeField] Text messageText;

    PartyMemberUI[] memberSlots;
    List<Pepemon> pepemons;

    public void Init()
    {
        memberSlots = GetComponentsInChildren<PartyMemberUI>();
    }

    public void SetPartyData(List<Pepemon> pepemons)
    {
        this.pepemons = pepemons;

        for (int i = 0; i < memberSlots.Length; i++)
        {
            if (i < pepemons.Count)
                memberSlots[i].SetData(pepemons[i]);
            else
                memberSlots[i].gameObject.SetActive(false);
        }

        messageText.text = "Choose a Pepemon";
    }

    public void UpdateMemberSelection(int selectedMember)
    {
        for (int i = 0; i < pepemons.Count; i++)
        {
            if (i == selectedMember)
                memberSlots[i].SetSelected(true);
            else
                memberSlots[i].SetSelected(false);
        }
    }

    public void SetMessageText(string message)
    {
        messageText.text = message;
    }
}
