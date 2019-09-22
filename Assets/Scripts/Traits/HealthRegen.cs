using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthRegen : StaticTrait
{

    private GameObject player;

    private float tickCD;
    private float cooldown;
    private float healpercent;
    private Hero hero;

    void Start()
    {
        hero = GameObject.Find("Hero").GetComponent<Hero>();
        tickCD = 5;
        cooldown = Time.time + tickCD;
        player = GameObject.Find("Hero");
        healpercent = player.GetComponent<Hero>().maxHealth.value * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= Time.time && hero.currentHealth.value <= hero.maxHealth.value)
        {
            player.GetComponent<Hero>().currentHealth.value += healpercent;
            cooldown = Time.time + tickCD;
        }
    }

    void onDestroy()
    {
        player.GetComponent<Hero>().attackCooldown *= 1.1f;
    }
}
