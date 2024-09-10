using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinMenuScript : MonoBehaviour
{
    #region CurrentLevel
    public TextMeshProUGUI CurrentLevelText;
    private int currentLevel;
    #endregion


    // Start is called before the first frame update
    void Awake()
    {
       UpdateCurrentLevel();
    }


    void UpdateCurrentLevel()
    {
        currentLevel++;
        CurrentLevelText.text = "Completed Level: " + currentLevel;
        // Save the currentLevel in memory
    }
}
