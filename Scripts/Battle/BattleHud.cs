using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Pepemon _pepemon;

    public void SetData(Pepemon pepemon)
    {
        _pepemon = pepemon;

        nameText.text = pepemon.Base.Name;
        levelText.text = "Lvl " + pepemon.Level;
        hpBar.SetHP((float) pepemon.HP / pepemon.MaxHp);
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_pepemon.HP / _pepemon.MaxHp);
    }
}
