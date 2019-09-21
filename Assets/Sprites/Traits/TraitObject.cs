using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitObject : MonoBehaviour
{

    public GameObject traitObject;

    public Text nameText;
    public Text descriptionText;
    public Text cost;
    public Image icon;

    public bool showDesc;

    public Trait trait;
    // Start is called before the first frame update
    void Start()
    {
        trait = traitObject.GetComponent<StaticTrait>().trait;
        showDesc = false;

        nameText.text = trait.traitName;
        descriptionText.text = trait.description;
        cost.text = trait.cost.ToString();
        icon.sprite = trait.icon;
    }

    private void FixedUpdate()
    {
        trait = traitObject.GetComponent<StaticTrait>().trait;
        nameText.text = trait.traitName;
        descriptionText.text = trait.description;
        cost.text = trait.cost.ToString();
        icon.sprite = trait.icon;
    }

    public void toggleDescription()
    {
        showDesc = !showDesc;
    }

    public void addTrait()
    {
        GameObject newtrait = Instantiate(traitObject);
        newtrait.transform.parent = GameObject.Find("Traits").transform;
    }

}
