using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Hero");
        cooldown = Time.time + attackCooldown;
    }

    private void FixedUpdate()
    {
        updateHealthBar();
        player = GameObject.Find("Hero");
    }


    // Update is called once per frame
    void Update()
    {
        
        GameObject c = GameObject.Find("Center");
        if (Vector3.Distance(transform.position, player.transform.position) >= attackRange)
        {
            
            Vector3 moveTarget = new Vector3(player.transform.position.x, c.transform.position.y, 0);
            print("oor"+moveTarget);
            transform.position = Vector3.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
        }
        else
        {
            print("ir");
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

    private void updateHealthBar()
    {
        float healthPercentage = currentHealth / (maxHealth / 100);
        healthBar.GetComponent<Image>().fillAmount = healthPercentage / 100;
        if(currentHealth <= 0) { Destroy(transform.gameObject); }
    }
}
