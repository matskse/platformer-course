using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 25;
    bool active = true;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.GetComponent<EnemyHealth>() && active) {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if (other.gameObject.GetComponent<PlayerHealth>() && active) {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        active = false;
    }
}
