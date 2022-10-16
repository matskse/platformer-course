using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public GameObject bullet;
    public GameObject muzzle;
    public GameObject gunBase;

    //TODO: Find a suitable bullet speed
    int bulletSpeed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // TODO: Instantiate a bullet prefab at the muzzle position. Find the direction to shoot. Set the bullet's velocity.
    void Shoot() {
        return;
    }


    // TODO: Shoot() when this input is called.
    public void OnShootButtonInput(InputAction.CallbackContext context) {
        if (context.performed) {
            Debug.Log("Shoot!");
        }
    }

    
}
