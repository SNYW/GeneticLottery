using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float health;
    public float attackPower;
    public float attackCooldown;
    public float cooldown;
    public float speed;
    public string damageType;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = Time.time + attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject h = GameObject.Find("Hero");
        GameObject c = GameObject.Find("Center");
        if (Vector3.Distance(transform.position, h.transform.position) >= 1)
        {
            Vector3 moveTarget = new Vector3(h.transform.position.x - 1, c.transform.position.y, 0);
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
        }
        else
        {
            attack();
        }
        
        
    }

    public void attack()
    {
        if (cooldown <= Time.time)
        {
            player.GetComponent<DamageManager>().takeDamage(attackPower, damageType);
            cooldown = Time.time + attackCooldown;
        }
    }
}
