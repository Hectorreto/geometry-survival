using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Transform redBar;

    private int initialHealth;
    
    void Start()
    {
        initialHealth = target.GetComponent<BossManager>().getHealth();
    }
    
    void Update()
    {
        if (target != null)
        {
            this.transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 1.6f);

            // obtener porcentaje de vida
            int currentHealth = target.GetComponent<BossManager>().getHealth();
            float percentage = (float)currentHealth / initialHealth;

            // cambiar tamaño de la barra roja
            redBar.localScale = new Vector2(percentage, redBar.localScale.y);
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
