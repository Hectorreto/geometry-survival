using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovementWithRotation : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float speed = 1f;
    public float rotationSpeed = 1f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null) 
        {
            // look at player
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed * Time.deltaTime);
        }

        // move 
        rb.velocity = transform.right * speed;
    }


}

