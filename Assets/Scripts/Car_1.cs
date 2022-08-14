using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Refers to each vehicle in the scene.
public class Car_1 : MonoBehaviour
{
    // Car speed.
    public float speed = 5;
    // Vector for wheel rotation.
    public Vector3 rotator;
    Rigidbody body;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        // Instantiate car velocity.
        body.velocity = transform.forward * speed;   
        // Set rotation around the wheel x-axis.
        rotator = new Vector3(45, 0, 0);
    }

    void Update() 
    {
        setWheelRotation();
    }

    // Set wheel rotation animation.
    void setWheelRotation()
    {
        // Iterate through children components of car prefab (wheels).
        for (int i = 0; i < transform.childCount-1; i++)
        {
            // Rotate at realtime.
            transform.GetChild(i).Rotate(rotator * 2 * speed * Time.deltaTime);
        } 
    }

    // Freeze car on Player collision.
    void OnCollisionEnter(Collision other) 
    {
        body.isKinematic = true;   
    }
}
