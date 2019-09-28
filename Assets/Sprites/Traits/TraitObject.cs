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
    public Playstat currency;

    public bool showDesc;

    public Trait trait;

    public GameObject traitStackManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void FixedUpdate()
    {
        if (traitObject != null)
        {
            trait = traitObject.GetComponent<StaticTrait>().trait;
            nameText.text = trait.traitName;
            descriptionText.text = trait.description;
            cost.text = trait.cost.ToString();
            icon.sprite = trait.icon;
        }
    }

    public void toggleDescription()
    {
        showDesc = !showDesc;
    }

    public void addTrait()
    {
        currency.value -= int.Parse(cost.text);
        print(traitObject);
        GameObject.Find("GameManager").GetComponent<GameManager>().addNewTrait(gameObject);
        this.traitObject = null;
        this.trait = null;
        nameText.text = "SOLD";
        descriptionText.text = null;
        cost.text = null;
        icon.sprite = null;
    }

}
