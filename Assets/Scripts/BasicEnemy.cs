using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private GameObject player;
    public float speed = 5f;
    private Rigidbody2D rb;
    public ParticleSystem ps;

    // This is used so scripts can know when an enemy is destroyed
    public Action OnDestroy = () => {};

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // move towards the player
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speed;
        
        // rotate to face the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
            OnDestroy();
        }
    }
}
