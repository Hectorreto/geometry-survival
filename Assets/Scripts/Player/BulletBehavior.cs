using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] public float damage = 1;
    [SerializeField] public float damageToIncrease = 1;
    [SerializeField] public GameObject LevelUpUI;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BasicEnemy enemy = collision.GetComponent<BasicEnemy>();
        if (enemy != null)
        {
            enemy.ReceiveDamage(damage);
            Destroy(gameObject);
        }
    }

    //public void IncreaseDamage()
    //{
    //    LevelUpUI = GameObject.Find("LevelUpUI");
    //    print("Last damage: " + damage);
    //    damage += damageToIncrease;
    //    print("New damage: " + damage);
    //    LevelUpUI.SetActive(false);
    //    Time.timeScale = 1;
    //}
}
