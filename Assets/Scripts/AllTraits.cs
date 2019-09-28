using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllTraits : ScriptableObject
{
    public List<GameObject> allTraits;
    
    public GameObject getRandomTrait()
    {
        GameObject randomTrait = allTraits[Random.Range(0, allTraits.Count)];
        return randomTrait;
    }
}
