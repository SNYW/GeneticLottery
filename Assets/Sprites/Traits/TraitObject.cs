using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitObject : MonoBehaviour
{

    public Trait trait;

    public Text nameText;
    public Text descriptionText;
    public Text cost;
    public Image icon;

    public bool showDesc;

    // Start is called before the first frame update
    void Start()
    {
        showDesc = false;

        nameText.text = trait.traitName;
        descriptionText.text = trait.description;
        cost.text = trait.cost.ToString();
        icon.sprite = trait.icon;
    }
    
    public void toggleDescription()
    {
        showDesc = !showDesc;
    }

}
