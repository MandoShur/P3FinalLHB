using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; 
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            UnityEngine.Debug.LogError("Rigidbody2D component not found on player.");
        }
    }

    void Update()
    {
        // Handle player input and movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY) * speed;

        rb.velocity = movement; // Apply movement to the Rigidbody2D
    }

}     
       
 


            

