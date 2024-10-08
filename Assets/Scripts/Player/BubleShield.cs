using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleShield : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private CombatManager combatManager;

    private void FixedUpdate()
    {
        if (combatManager.currentHealth > 0)
        {
            transform.position = player.transform.position;
            transform.Rotate(0, 0, 1);
        }
    }
}
