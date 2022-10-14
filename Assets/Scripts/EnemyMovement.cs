using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    CapsuleCollider2D capsuleCollider;
    [SerializeField]
    int movementSpeed = 200,
    maxSpeed = 4;

    [SerializeField]
    private LayerMask layer;

    int movementDirection = 1;

    float turnAroundTimer = 0.5f;

    public bool shouldMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void FixedUpdate()
    {
        if (shouldMove) {
            Move();
            flipTowardsMovement();
            lookForWalls();
            turnAroundTimer -= Time.deltaTime;
        }
        handleAnimations();
    }

    void Move() {
        if (Mathf.Abs(rb.velocity.x) < maxSpeed) {
            Vector2 movementForce = new Vector2(movementDirection * movementSpeed, 0);
            rb.AddForce(movementForce);
        }
    }

    void lookForWalls() {
        float distanceControlParam = 1f;
        Vector3 lookDir = new Vector3(movementDirection, 0, 0);
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, lookDir, distanceControlParam, layer);
        Debug.DrawRay(capsuleCollider.bounds.center, lookDir * distanceControlParam);
        if (raycastHit.collider != null && raycastHit.collider != capsuleCollider && turnAroundTimer <= 0) {
            movementDirection *= -1;
            turnAroundTimer = 0.5f;
        }
    }

    private void flipTowardsMovement() {
        if (movementDirection < 0) {
            transform.localScale= new Vector3(-1, 1, 1);
        }
        else if (movementDirection > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void handleAnimations() {
        anim.SetBool("Running", Mathf.Abs(rb.velocity.x) > 0.2f);
    }
}
