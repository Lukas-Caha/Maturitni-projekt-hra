using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PepemonParty : MonoBehaviour
{
    [SerializeField] List<Pepemon> pepemons;

    public List<Pepemon> Pepemons {
        get {
            return pepemons;
        }
    }

    private void Start()
    {
        foreach (var pepemon in pepemons)
        {
            pepemon.Init();
        }
    }

    public Pepemon GetHealthyPepemon()
    {
        return pepemons.Where(x => x.HP > 0).FirstOrDefault();
    }
}
