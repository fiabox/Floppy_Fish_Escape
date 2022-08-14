using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Refers to the Player fish.
public class Fish : MonoBehaviour
{
    Rigidbody body;
    bool jumpPressed;
    bool isGrounded;
    Renderer render;

    // Jump thrust.
    public float jumper;
    // Vector for random fish rotation.
    public Vector3 rotator;
    // Material for damage animation.
    public Material hitMaterial;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        // Call Spasm method every 2 seconds.
        InvokeRepeating("Spasm", 1f, 2f); 
        render = GetComponent<Renderer>();

    }

    void Update()
    {
        // Disable jumping if player is currently in the air.
        if (!isGrounded)
        {
            return;
        }
        // Else check for space key input.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
            // Randomly generate rotator vector.
            rotator = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));          
        } 
    }

    void FixedUpdate() 
    {
        if(jumpPressed)
        {  
            // Enables random rotation while jumping for control difficulty.
            body.AddForce(new Vector3(0.5f,10,0) * jumper, ForceMode.VelocityChange);
            transform.Rotate(rotator);
            jumpPressed = false;
        }  
    }

    // Check player position to disable multi jump.
    void OnCollisionEnter(Collision target)
    {
        isGrounded = true;    

        // Check for collision with vehicle.
        if(target.gameObject.tag == "Finish")
        {
            // Start hit animation.
            render.sharedMaterial = hitMaterial;
            // Destroy player after delay of 2 seconds.
            Invoke("destroy", 2f);
        }
    }

    // Check if player is currently in the air.
    void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    // Makes the fish do cute little flops.
    void Spasm()
    {
        body.AddForce(Vector3.up, ForceMode.VelocityChange);
    }

    void destroy() 
    {
        Destroy(gameObject);
    }
}
