using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pepemon", menuName = "Pepemon/Create new pepemon")]
public class PepemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] PepemonType type1;
    [SerializeField] PepemonType type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public PepemonType Type1
    {
        get { return type1; }
    }

    public PepemonType Type2
    {
        get { return type2; }
    }

    public int MaxHp
    {
        get { return maxHp; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int SpAttack
    {
        get { return spAttack; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int SpDefense
    {
        get { return spDefense; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

public enum PepemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon
}

public enum Stat
{
    Attack,
    Defense,
    SpAttack,
    SpDefense,
    Speed
}

public class TypeChart
{
    static float[][] chart =
    {
        new float[] { 1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,  0.5f,  0f,   1f },
        new float[] { 1f,  0.5f, 0.5f,  1f,   2f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,  0.5f,  1f,  0.5f },
        new float[] { 1f,   2f,  0.5f,  1f,  0.5f,  1f,   1f,   1f,   2f,   1f,   1f,   1f,   2f,   1f,  0.5f },
        new float[] { 1f,   1f,   2f,  0.5f, 0.5f,  1f,   1f,   1f,   0f,   2f,   1f,   1f,   1f,   1f,  0.5f },
        new float[] { 1f,  0.5f,   2f,   1f,  0.5f,  1f,   1f,  0.5f,  2f,  0.5f,  1f,  0.5f,  2f,   1f,  0.5f },
        new float[] { 1f,  0.5f, 0.5f,  1f,   2f,  0.5f,  1f,   1f,   2f,   2f,   1f,   1f,   1f,   1f,   2f },
        new float[] { 2f,   1f,   1f,   1f,   1f,   2f,   1f,  0.5f,  1f,  0.5f, 0.5f, 0.5f,  2f,   0f,   1f },
        new float[] { 1f,   1f,   1f,   1f,   2f,   1f,   1f,  0.5f, 0.5f,  1f,   1f,   1f,  0.5f, 0.5f,   1f },
        new float[] { 1f,   2f,   1f,   2f,  0.5f,  1f,   1f,   2f,   1f,   0f,   1f,  0.5f,   2f,   1f,   1f },
        new float[] { 1f,   1f,   1f,  0.5f,  2f,   1f,   2f,   1f,   1f,   1f,   1f,   2f,  0.5f,   1f,   1f },
        new float[] { 1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   1f,   1f,  0.5f,  1f,   1f,   1f,   1f },
        new float[] { 1f,  0.5f,  1f,   1f,   2f,   1f,  0.5f, 0.5f,  1f,  0.5f,  2f,   1f,   1f,  0.5f,   1f },
        new float[] { 1f,   2f,   1f,   1f,   1f,   2f,  0.5f,  1f,  0.5f,  2f,   1f,   2f,   1f,   1f,   1f },
        new float[] { 0f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   2f,   1f,   1f,   2f,   1f },
        new float[] { 1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   2f }
    };

    public static float GetEffectiveness(PepemonType attackType, PepemonType defenseType)
    {
        if (attackType == PepemonType.None || defenseType == PepemonType.None)
            return 1;

        int row = (int)attackType - 1;
        int col = (int)defenseType - 1;

        if (row < 0 || row >= chart.Length || col < 0 || col >= chart[0].Length)
        {
             Debug.LogError($"Hele, s těmahle typama (útok: {attackType}, obrana: {defenseType}) si nevím rady. Vracím normální škodu.");
             return 1f;
        }

        return chart[row][col];
    }
}