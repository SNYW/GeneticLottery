using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Game Statistics
    public Playstat experience;
    public Playstat currency;

    public bool moving;
    public float expPerLevel;
    public float expToLevel;
    public float gameLevel;
    public GameObject expBar;
    public GameObject spawners;

    private void Start()
    {
        resetGame();
    }

    private void Update()
    {
        manageGameLevel();
        manageExpBar();
        spawnBoss();
    }

    public void resetGame()
    {
        experience.value = 0;
        currency.value = 200;
    }

    void manageGameLevel()
    {
        if(experience.value >= expToLevel)
        {
            onLevelUp();
        }
    }

    void manageExpBar()
    {
        float currentExpPercentage = experience.value / (expToLevel / 100f);
        expBar.GetComponent<Image>().fillAmount = currentExpPercentage/100;
    }

    void onLevelUp()
    {


        if (spawners.GetComponent<EnemySpawner>().spawnCooldown >= 0.4 && gameLevel < 10)
        {
            spawners.GetComponent<EnemySpawner>().enemyAmount += 5 * (int)gameLevel;
            spawners.GetComponent<EnemySpawner>().spawnCooldown -= 0.1f;
        }
        
        gameLevel++;
        experience.value = 0;
        expToLevel = expPerLevel * gameLevel;
        currency.value += 75*gameLevel;
    }

    private bool canSpawnBoss()
    {
        return gameLevel >= 10 && spawners.GetComponent<EnemySpawner>().enemyAmount <= 0;
    }

    void spawnBoss()
    {
        if (canSpawnBoss())
        {
            spawners.GetComponent<EnemySpawner>().canSpawnBoss = true;
        }
    }
}
