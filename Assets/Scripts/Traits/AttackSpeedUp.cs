using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackSpeedUp : StaticTrait
{

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Hero");
        player.GetComponent<Hero>().attackCooldown *= 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDestroy()
    {
        player.GetComponent<Hero>().attackCooldown *= 1.1f;
    }
}
