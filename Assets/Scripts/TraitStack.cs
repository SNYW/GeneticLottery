using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitStack : MonoBehaviour
{
    
    public GameObject[] traitStackSpots;

    public activeTraitsList activeTraitsList;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        manageTraitStackSpots();
    }

    private void manageTraitStackSpots()
    {
        int index = 0;
        foreach (Trait key in activeTraitsList.allActiveTraits.Keys)
        {
            if (traitStackSpots[index].GetComponent<TraitStackObject>().trait == null)
            {
                traitStackSpots[index].GetComponent<TraitStackObject>().trait = key;
                traitStackSpots[index].GetComponent<TraitStackObject>().setStacks(activeTraitsList.allActiveTraits[key]);
                traitStackSpots[index].GetComponent<TraitStackObject>().Image.GetComponent<Image>().enabled = true;
                print(activeTraitsList.allActiveTraits[key]+"-------"+ traitStackSpots[index].GetComponent<TraitStackObject>().stacks);

            }
            else
            {
                if(traitStackSpots[index].GetComponent<TraitStackObject>().trait == key)
                {
                  traitStackSpots[index].GetComponent<TraitStackObject>()
                        .setStacks(activeTraitsList.allActiveTraits[key]);
                }
            }
            index++;
        }
    }
}
