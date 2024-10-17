using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAndStatsTracker : MonoBehaviour
{
    private int actualExp = 0;
    private int playerLevel = 1;
    [SerializeField] GameObject LevelUpUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetExp(int ExpToAdd)
    {
        actualExp += ExpToAdd;
        print("Currently Exp: " + actualExp);

        if (actualExp >= 20)
        {
            //Stats selection
            playerLevel += 1;
            actualExp = 0;
            print("Level up to: " + playerLevel);
            print("Chose your upgrade");
            LevelUpUI.SetActive(true);
            //pausar el juego
            Time.timeScale = 0;
        }
    }

}
