using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    [SerializeField] List<Pepemon> wildPepemons;

    public Pepemon GetRandomWildPepemon()
    {
        var wildPepemon = wildPepemons[Random.Range(0, wildPepemons.Count)];
        wildPepemon.Init();
        return wildPepemon;
    }
}