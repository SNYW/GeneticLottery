﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public string enemyName;
    public float maxHealth;
    public float currentHealth;
    public float attackPower;
    public float attackCooldown;
    public float cooldown;
    public float speed;
    public float attackRange;
    public string damageType;
    public Image healthBar;
    public bool attacking;
    public Animator animator;
    public bool isDead;

    //code for loot drops
    public int maximumLoot;
    public int minimumLoot;
    public GameObject[] possibleDrops;


    //Code for directional movement tracking
    private Vector3 lastPos;
    public Vector3 velocity;
    private GameObject c;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Hero");
        cooldown = Time.time + attackCooldown;
        c = GameObject.Find("Center");
    }

    private void FixedUpdate()
    {
        animator.SetBool("Attacking", attacking);
        updateHealthBar();
        getDirection();
    }


    // Update is called once per frame
    void Update()
    {
        moveToPlayer();
    }

    void moveToPlayer()
    {
        if (!isDead)
        {
            if (Vector3.Distance(transform.position, player.transform.position) >= attackRange+(transform.lossyScale.x/10))
            {
                animator.SetFloat("Speed", 1);
                attacking = false;
                Vector3 moveTarget = new Vector3(player.transform.position.x, c.transform.position.y, 0);
                transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
            }
            else
            {
                animator.SetFloat("Speed", 0);
                attack();
            }
        }
    }

    public void attack()
    {
        if (player.transform.position.x < transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (cooldown <= Time.time)
        {
            attacking = true;
            player.GetComponent<DamageManager>().takeDamage(attackPower, damageType);
            cooldown = Time.time + attackCooldown;
        }
    }

    private void updateHealthBar()
    {
        float healthPercentage = currentHealth / (maxHealth / 100);
        healthBar.GetComponent<Image>().fillAmount = healthPercentage / 100;
        if(currentHealth <= 0)
        {
            onDeath();
        }
    }

    private void getDirection()
    {
        velocity = transform.position - lastPos;
        lastPos = transform.position;

        if (velocity.x < 0 && !attacking)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void onDeath()
    {
        int dropamount = Random.Range(minimumLoot, maximumLoot);
        for (int i = 0; i < dropamount; i++)
        {
            GameObject loot = Instantiate(possibleDrops[Random.Range(0, possibleDrops.Length)], transform.position, Quaternion.identity);
            loot.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(2, 5), ForceMode2D.Impulse);
            loot.GetComponent<Rigidbody2D>().AddTorque(Random.Range(2, 10));
            Destroy(gameObject);
        }
    }

}
