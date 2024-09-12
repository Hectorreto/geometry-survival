using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashForce = 100f;

    private Rigidbody2D rb;
    private float dashingRemainingTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "DashPowerup":
                print("Dash collected!");
                Destroy(collision.gameObject);
                dashingRemainingTime = dashTime;
                break;

            case "BubblePowerup":
                print("Bubble collected!");
                Destroy(collision.gameObject);
                break;
        }
    }

    void Dash()
    {
        if (dashingRemainingTime > 0)
        {
            dashingRemainingTime -= Time.deltaTime;
            rb.AddForce(transform.right * dashForce);
        }
    }
}
