using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitStackObject : MonoBehaviour
{
    public Trait trait;
    public int stacks;
    public Text traitName;
    public GameObject Image;

    public GameObject[] bars;

    private void Start()
    {
        resetBars();
        traitName.text = null;
        Image.GetComponent<Image>().enabled = false;
        
    }

    private void FixedUpdate()
    {
        
        if (trait != null)
        {
            traitName.text = trait.traitName + " X" + stacks; ;
            manageStackImages();
        }
    }

    void manageStackImages()
    {
        for(int i = 0; i <= stacks-1; i++)
        {
            bars[i].GetComponent<Image>().enabled = true;
        }
    }

    void resetBars()
    {
        foreach (GameObject b in bars)
        {
            b.GetComponent<Image>().enabled = false;
        }
    }

    public void incrementStacks()
    {
        stacks++;
    }

    public void setStacks(int s)
    {
        stacks = s;
    }
}
