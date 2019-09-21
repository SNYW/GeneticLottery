using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AllTraits : ScriptableObject
{

    public Trait[] allTraits;

    
    public Trait getRandomTrait()
    {
        Trait randomTrait = allTraits[Random.Range(0, allTraits.Length)];
        return randomTrait;
    }
}
