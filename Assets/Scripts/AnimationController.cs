using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.1f) {
            animator.SetBool("Running", true);
        }
        else {
            animator.SetBool("Running", false);
        }
    }
}
