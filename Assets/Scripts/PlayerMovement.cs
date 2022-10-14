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
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
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
        flipTowardsMovement();
        isGrounded();
        
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
        float heightControlParam = 0.2f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center,capsuleCollider.bounds.size, 0, Vector2.down, heightControlParam, groundLayer);
        return raycastHit.collider != null;
    }

    private void flipTowardsMovement() {
        if (inputVector.x < 0) {
            transform.localScale= new Vector3(-1, 1, 1);
        }
        else if (inputVector.x > 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void handleAnimations() {
        animator.SetBool("Falling", !isGrounded());
        animator.SetBool("Running", Mathf.Abs(rb.velocity.x) > 0.2f);
    }
}
