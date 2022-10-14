using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject bullet;
    public GameObject muzzle;
    public GameObject gunBase;
    int bulletSpeed = 20;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void Shoot() {
        GameObject b = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        if (transform.localScale.x < 0) {
            b.GetComponent<SpriteRenderer>().flipX = true;
        }
        Vector3 dir = (muzzle.transform.position - gunBase.transform.position).normalized;
        b.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
    }

    public void OnShootButtonInput(InputAction.CallbackContext context) {
        if (context.performed) {
            Shoot();
        }
    }

    
}
