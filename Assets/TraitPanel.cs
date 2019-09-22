using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitPanel : MonoBehaviour
{

    public GameObject[] traitOptions;
    public AllTraits allTraits;

    void Start()
    {
        refreshTraitOptions();
    }

    public void refreshTraitOptions()
    {
        foreach(GameObject option in traitOptions)
        {
            //print("refreshing " + option);
            option.GetComponent<TraitObject>().trait = null;
            option.GetComponent<TraitObject>().traitObject = allTraits.getRandomTrait();
        }
    }
}
