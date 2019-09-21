using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StrengthUp : StaticTrait
{

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Hero");
        player.GetComponent<Hero>().strength *= 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDestroy()
    {
        player.GetComponent<Hero>().strength /= 0.9f;
    }
}
