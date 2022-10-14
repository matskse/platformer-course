using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;
    public GameObject gunBase;

    [SerializeField]
    int bulletSpeed = 30;

    [SerializeField]
    float shootingInterval = 2f;
    float shootTimer;

    Animator anim;

    void Start()
    {
        shootTimer = shootingInterval;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0) {
            Shoot();
        }
    }

    void Shoot() {
        anim.SetTrigger("shoot");
        GameObject b = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        if (transform.localScale.x < 0) {
            b.GetComponent<SpriteRenderer>().flipX = true;
        }
        Vector3 dir = (muzzle.transform.position - gunBase.transform.position).normalized;
        b.GetComponent<Rigidbody2D>().velocity = dir * bulletSpeed;
        shootTimer = shootingInterval;
    }
}
