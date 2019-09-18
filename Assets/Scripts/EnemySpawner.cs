using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTypes;
    public GameObject[] Spawners;
    public int enemyAmount;
    public float spawnCooldown;
    private float cooldown;

    private void Awake()
    {
        cooldown = Time.time + spawnCooldown;
        
    }

    private void Update()
    {
        checkSpawnTimer();


    }

    private void checkSpawnTimer()
    {
        if (cooldown <= Time.time)
        {
            spawnEnemy(enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Length)]);
            cooldown = Time.time + spawnCooldown;
        }
    }

    void spawnEnemy(GameObject enemy)
    {
        GameObject s = Instantiate(enemy, Spawners[UnityEngine.Random.Range(0, Spawners.Length)].transform.position, Quaternion.identity);
        s.transform.parent = GameObject.Find("Enemies").transform;
    }


}
