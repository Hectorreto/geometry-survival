using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    private CombatManager combatManager;

    private void Start()
    {
        //combatManager = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatManager>();
        //combatManager.PlayerDeath += ActivateInterface;

    }

    //private void ActivateInterface(object sender, EventArgs e)
    //{
    //    print("Si me activo");
    //    gameOverMenu.SetActive(true);
    //}

    private void activateMenu(object sender, EventArgs e)
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void MainMenu(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        // UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
