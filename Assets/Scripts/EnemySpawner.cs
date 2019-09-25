using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTypes;
    public GameObject[] bossTypes;
    public GameObject[] Spawners;
    public int enemyAmount;
    public int bossAmount;
    public float spawnCooldown;
    private float cooldown;
    public GameObject Center;
    public bool canSpawnBoss;

    private void Awake()
    {
        cooldown = Time.time + spawnCooldown;
    }

    private void Update()
    {
        checkSpawnTimer();
        spawnBoss();
    }

    private void checkSpawnTimer()
    {
        if (cooldown <= Time.time && enemyAmount > 0)
        {
            
            spawnEnemy(enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Length)]);
            cooldown = Time.time + spawnCooldown;
        }
    }

    void spawnEnemy(GameObject enemy)
    {
        Vector3 spawnplace = new Vector3(Spawners[UnityEngine.Random.Range(0, Spawners.Length)].transform.position.x, Center.transform.position.y, 0);
        GameObject s = Instantiate(enemy, spawnplace , Quaternion.identity);
        s.transform.parent = GameObject.Find("Enemies").transform;
        enemyAmount --;
    }
    
    void spawnBoss()
    {
        if(enemyAmount == 0 && canSpawnBoss)
        {
            Vector3 spawnplace = new Vector3(Spawners[UnityEngine.Random.Range(0, Spawners.Length)].transform.position.x, Center.transform.position.y, 0);
            GameObject s = Instantiate(bossTypes[UnityEngine.Random.Range(0, bossTypes.Length)],
                           spawnplace, Quaternion.identity);
            s.transform.parent = GameObject.Find("Enemies").transform;
            enemyAmount--;
        }
    }


}
