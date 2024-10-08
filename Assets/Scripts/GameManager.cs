using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Score
    public TextMeshProUGUI scoreText;
    private int score;
    #endregion

    #region Countdown
    [SerializeField] private int startMinutes = 10;
    private float remainingTime;
    public TextMeshProUGUI countDownText;
    #endregion

    [SerializeField] GameObject WinMenu;

    public bool hasWon = false;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private EnemySpawner greenEnemySpawner;
    [SerializeField] private EnemySpawner redEnemySpawner;
    [SerializeField] private EnemySpawner purpleEnemySpawner;
    [SerializeField] private GameObject enemyBoss;

    // Start is called before the first frame update
    void Start()
    {
        remainingTime = startMinutes * 60;//convert minutes to seconds
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        SetCountDown();
        HasWonTheLevel(hasWon);

        checkDifficulty();
    }

    private void checkDifficulty()
    {
        int timeForRedEnemies = 420; // 7 minutes remaining
        int timeForPurpleEnemies = 240; // 4 minutes remaining
        int timeForBossFight = 60; //1 minute remaining

        if (remainingTime < timeForRedEnemies) {
            redEnemySpawner.enabled = true;

            // Background music 2
            //print("Change to backgroundmusic2")
        }

        if (remainingTime < timeForPurpleEnemies)
        {
            purpleEnemySpawner.enabled = true;

            // Background music 3
            //print("Change to backgroundmusic3")
        }

        if (remainingTime < timeForBossFight)
        {
            enemyBoss.SetActive(true);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    void SetCountDown()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            countDownText.text = "00:00";
            //Play a completed level sound effect
            hasWon = true;
        }
    }

    void HasWonTheLevel(bool hasWon)
    {
        if (hasWon)
        {
            WinMenu.SetActive(hasWon);
            Time.timeScale = 0;
        }
    }

   public void LoadNextLevel(string LevelName)
    {
        // SceneManager.LoadScene(LevelName);
        Debug.Log("Se carg� el nivel: " + LevelName);
    }

}
