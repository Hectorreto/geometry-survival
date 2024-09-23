using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubleShield : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void FixedUpdate()
    {
        transform.position = player.transform.position;
        transform.Rotate(0, 0, 1);
    }
}
