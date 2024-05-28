using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    private Movement movement;

    private void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        //movement.CheckHealth += ActivateMenu;

    }

    private void activateMenu(object sender, EventArgs e)
    {
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Exit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
