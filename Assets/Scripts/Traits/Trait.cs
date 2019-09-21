using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Trait : ScriptableObject
{
    public string traitName;
    public string description;
    public Sprite icon;
    public int cost;
    public StaticTrait effects;

}
