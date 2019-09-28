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
    public activeTraitsList activeTraitsList;
    public AllTraits allTraits;
    public List<GameObject> remainingTraits;
    public Text bonusText;

    private void Start()
    {
        resetGame();
    }

    private void Update()
    {
        showBonusAmount();
        manageGameLevel();
        manageExpBar();
        spawnBoss();
    }

    public void resetGame()
    {
        experience.value = 0;
        currency.value = 3;
        foreach(GameObject t in allTraits.allTraits)
        {
            remainingTraits.Add(t);
        }
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
        currency.value += 4+((int)currency.value/10);
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

    void showBonusAmount()
    {
        bonusText.text = "Income = 4+"+ ((int)currency.value / 10);
    }

    public void incrementStacks(GameObject t)
    {
        if (activeTraitsList.allActiveTraits.ContainsKey(t.GetComponent<TraitObject>().trait))
        {   
            if(activeTraitsList.allActiveTraits[t.GetComponent<TraitObject>().trait] < 4)
            {
                activeTraitsList.allActiveTraits[t.GetComponent<TraitObject>().trait]++;
                if(activeTraitsList.allActiveTraits[t.GetComponent<TraitObject>().trait] >= 4)
                {
                    print("WTF" + t);
                    removeTrait(t.GetComponent<TraitObject>().traitObject);
                }
            }
            else
            {
                print("WTFffffffff" + t);
                removeTrait(t.GetComponent<TraitObject>().traitObject);
            }
            
        }
    }

    public void addNewTrait(GameObject t)
    {
        print(t.GetComponent<TraitObject>().trait);
        if (!activeTraitsList.allActiveTraits.ContainsKey(t.GetComponent<TraitObject>().trait))
        {
            activeTraitsList.allActiveTraits.Add(t.GetComponent<TraitObject>().trait, 1);
        }
        else
        {
            incrementStacks(t);
        }
    }

    public GameObject getRandomTrait()
    {
        GameObject randomTrait = remainingTraits[Random.Range(0, remainingTraits.Count)];
        return randomTrait;
    }

    public void removeTrait(GameObject g)
    {
        foreach(GameObject t in remainingTraits)
        {
            print(g.name + t.name);
            if(g.name == t.name)
            {
                remainingTraits.Remove(t);
            }
        }
    }

}
