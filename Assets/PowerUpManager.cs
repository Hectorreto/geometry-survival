using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpManager : MonoBehaviour
{
    #region Dash
    [Header("Dash Settings")]
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float dashForce = 100f;

    private float dashingRemainingTime = 0;
    private float dashCooldown = 0;
    private int dashCount = 0;
    [SerializeField] private GameObject dashShield;

    // UI Button
    [SerializeField] private TextMeshProUGUI dashCountText;
    [SerializeField] private GameObject powerupButton;
    #endregion

    private Rigidbody2D rb;
    private CombatManager combatManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        combatManager = GetComponent<CombatManager>();
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
                dashCount =+ 3;
                break;

            case "BubblePowerup":
                print("Bubble collected!");
                Destroy(collision.gameObject);
                break;
        }
    }

    private void Dash()
    {
        // UI Button
        dashCountText.text = dashCount.ToString();
        powerupButton.SetActive(dashCount > 0);
        
        // Cooldown
        dashCooldown -= Time.deltaTime;


        if (dashingRemainingTime > 0)
        {
            dashingRemainingTime -= Time.deltaTime;

            rb.AddForce(transform.right * dashForce * Time.deltaTime);
            combatManager.hasShield = true;
            dashShield.SetActive(true);
        }else
        {
            combatManager.hasShield = false;
            dashShield.SetActive(false);
        }
    }

    public void ActivateDash()
    {
        print("Dash Count: " + dashCount);

        if (dashCooldown > 0) return;
        if (dashCount >0)
        {
            dashCooldown = 1;
            dashingRemainingTime = dashTime;
            dashCount --;
            //activate UIDashButton 
        }
        else
        {
            //deactivate UIDashButton
        }
    }
}
