using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] public int currentDamage = 1;
    [SerializeField] public int damageToIncrease = 1;
    [SerializeField] public GameObject LevelUpUI;

    private void Start()
    {
        
    }
    public void IncreaseDamage()
    {
        LevelUpUI = GameObject.Find("LevelUpUI");
        print("Last damage: " + currentDamage);
        currentDamage += damageToIncrease;
        print("New damage: " + currentDamage);
        LevelUpUI.SetActive(false);
        Time.timeScale = 1;
    }
}
