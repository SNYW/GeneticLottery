using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Playstat experience;

    public bool moving;
    public float expPerLevel;
    public float expToLevel;
    public float gameLevel;
    public GameObject expBar;

    private void Start()
    {
        resetGame();
    }

    private void Update()
    {
        manageGameLevel();
        manageExpBar();
    }

    public void resetGame()
    {
        experience.value = 0;
    }

    void manageGameLevel()
    {
        if(experience.value >= expToLevel)
        {
            gameLevel++;
            experience.value = 0;
            expToLevel = expPerLevel * gameLevel;
        }
    }

    void manageExpBar()
    {
        float currentExpPercentage = experience.value / (expToLevel / 100f);
        expBar.GetComponent<Image>().fillAmount = currentExpPercentage/100;
    }
}
