using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private CombatManager combatManager;
    [SerializeField] private int hearthScore;

    void Start()
    {
        combatManager = GetComponent<CombatManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "HealthItem":
                print("Hearth collected!");
                Destroy(collision.gameObject);
                combatManager.AddHealth(1, hearthScore);
                break;

        }
    }
}
