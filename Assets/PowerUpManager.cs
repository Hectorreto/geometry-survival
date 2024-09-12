using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    Rigidbody2D rb;
    EmbededSyntax embededSyntax;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        embededSyntax = GetComponent<EmbededSyntax>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "DashPowerup":
                print("Dash collected!");
                Destroy(collision.gameObject);
                StartCoroutine(Dash());
                break;

            case "BubblePowerup":
                print("Bubble collected!");
                Destroy(collision.gameObject);
                break;
        }
    }

    IEnumerator Dash()
    {
        float originalSpeed = embededSyntax.speed;
        embededSyntax.speed *= 3;
        yield return new WaitForSeconds(0.2f);// Dash duration
        embededSyntax.speed = originalSpeed;
    }
}
