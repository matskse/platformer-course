using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 inputVector;
    [SerializeField]
    int jumpForce = 50,
    playerSpeed = 200,
    maxSpeed = 4;
    [SerializeField]
    private LayerMask groundLayer;
    private SpriteRenderer sr;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        inputVector = Vector2.zero;
        animator = GetComponent<Animator>();
    }

    
    void FixedUpdate()
    {   
        if (Mathf.Abs(rb.velocity.x) < maxSpeed) {
            Vector2 movementForce = new Vector2(inputVector.x * playerSpeed, 0);
            rb.AddForce(movementForce);
        }
        handleAnimations();
        flipSpriteTowardsMovement();
        
    }

    public void Jump(InputAction.CallbackContext context) {
        if (!isGrounded()) {
            return;
        }
        if (context.performed) {
            Vector2 forceVector = new Vector2(0, jumpForce);
            rb.AddForce(forceVector, ForceMode2D.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context) {
        inputVector = context.ReadValue<Vector2>();
    }

    private bool isGrounded() {
        float heightControlParam = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider.bounds.center, Vector2.down, capsuleCollider.bounds.extents.y + heightControlParam, groundLayer);
        // Debug.DrawRay(capsuleCollider.bounds.center, Vector2.down * (capsuleCollider.bounds.extents.y + heightControlParam));
        return raycastHit.collider != null;
    }

    private void flipSpriteTowardsMovement() {
        if (inputVector.x < 0) {
            sr.flipX = true;
        }
        else if (inputVector.x > 0) {
            sr.flipX = false;
        }
    }

    private void handleAnimations() {
        animator.SetBool("Falling", !isGrounded());
        animator.SetBool("Running", Mathf.Abs(rb.velocity.x) > 0.2f);
    }
}
