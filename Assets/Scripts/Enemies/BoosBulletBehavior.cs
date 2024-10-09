using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoosBulletBehavior : MonoBehaviour
{
    [SerializeField] int speed = 4;
    [SerializeField] float timeToAutoDestroy = 3f;
    [SerializeField] int damageToPlayer = 1;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, timeToAutoDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CombatManager>().TakeDamage(damageToPlayer);
            Destroy(this.gameObject);
        }
    }
}
