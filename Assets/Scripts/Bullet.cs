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

    // TODO: Call TakeDamage() of PlayerHealth and EnemyHealth if they exist on other.gameObject.
    void OnCollisionEnter2D(Collision2D other) {
        if (!active) {
            return;
        }
        Debug.Log(other);
        active = false;
    }
}
