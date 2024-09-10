using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
                break;

            case "BubblePowerup":
                print("Bubble collected!");
                Destroy(collision.gameObject);
                break;
        }
    }

}
