using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllTraits : ScriptableObject
{

    public GameObject[] allTraits;

    
    public GameObject getRandomTrait()
    {
        GameObject randomTrait = allTraits[Random.Range(0, allTraits.Length)];
        return randomTrait;
    }
}
