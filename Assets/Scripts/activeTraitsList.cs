using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class activeTraitsList : ScriptableObject
{
   public Dictionary<Trait, int> allActiveTraits = new Dictionary<Trait, int>();

}
