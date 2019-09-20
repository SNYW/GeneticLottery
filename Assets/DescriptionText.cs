using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionText : MonoBehaviour
{
    public GameObject parentTrait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<Text>().enabled = parentTrait.GetComponent<TraitObject>().showDesc;
    }

    
}
