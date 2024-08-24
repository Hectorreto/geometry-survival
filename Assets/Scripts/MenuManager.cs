using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits_Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
