using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitPanel : MonoBehaviour
{

    public GameObject[] traitOptions;
    public AllTraits allTraits;
    public activeTraitsList activeTraitsList;
    public float cost;

    void Start()
    {
        initialrefreshTraitOptions();
    }

    public void initialrefreshTraitOptions()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        foreach (GameObject option in traitOptions)
        {
            
            option.GetComponent<TraitObject>().trait = null;
            option.GetComponent<TraitObject>().traitObject = gm.getRandomTrait();
        }
    }
    public void refreshTraitOptions()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gm.currency.value >= cost)
        {
            gm.currency.value -= cost;
            foreach (GameObject option in traitOptions)
            {

                option.GetComponent<TraitObject>().trait = null;
                option.GetComponent<TraitObject>().traitObject = gm.getRandomTrait();
            }
        }
    }
}
