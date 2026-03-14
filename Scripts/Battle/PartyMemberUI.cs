using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberUI : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    [SerializeField] Color highlightedColor;

    Pepemon _pepemon;

    public void SetData(Pepemon pepemon)
    {
        _pepemon = pepemon;

        nameText.text = pepemon.Base.Name;
        levelText.text = "Lvl " + pepemon.Level;
        hpBar.SetHP((float)pepemon.HP / pepemon.MaxHp);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
            nameText.color = highlightedColor;
        else
            nameText.color = Color.black;
    }
}
