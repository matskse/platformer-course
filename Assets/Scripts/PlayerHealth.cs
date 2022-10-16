using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public bool dead = false;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    // TODO: Set the "die" trigger on the animator. Disable the Player inputs, Player attacks and Player movement components. Only die once. 
    void Die() {
        return;
    }

    // TODO: Decrease the health if we take damage. Call the Die() function when we die.
    public void TakeDamage(int amount) {
        return;
    }
}
