using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StaticTrait : MonoBehaviour
{

    public Trait trait;

    // Start is called before the first frame update
    void Start()
    {
        this.name = trait.traitName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDestroy()
    {

    }

}
