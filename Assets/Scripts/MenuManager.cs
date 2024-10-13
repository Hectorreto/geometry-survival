using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OpenCredits()
    {
        animator.SetTrigger("OpenCredits");
    }

    public void CloseCredits()
    {
        animator.SetTrigger("CloseCredits");
    }

    public void Quit()
    {
        // Quit the application
        Application.Quit();

        // Quit if we are in the Unity Editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
