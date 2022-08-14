using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages enemy spawning and intervals.
public class GameManager : MonoBehaviour
{
    // Spawnable vehicle object references.
    public GameObject car_1;
    public GameObject taxi;
    public GameObject bus;
    public GameObject car_2;

    void Start()
    {
       StartCoroutine(Spawn()); 
    }

    IEnumerator Spawn() 
    {
        while(true)
        {
            // Randomiser for car positions.
            float chooser = Random.Range(-1f, 1f);
            if (chooser > 0)
            {
            // Spawn variant 1:
            // Create car
            Instantiate(car_1, new Vector3(1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            // Wait until next spawn.
            yield return new WaitForSeconds(2.5f);

            Instantiate(car_2, new Vector3(-1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(0.5f);

            Instantiate(taxi, new Vector3(1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(2.5f);

            Instantiate(bus, new Vector3(-1.1f, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(1f);
            
            Instantiate(car_2, new Vector3(1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(2.5f);      
            } 
            else
            {
            // Spawn variant 2:
            Instantiate(car_1, new Vector3(-1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(1.5f);

            Instantiate(car_2, new Vector3(1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(0.5f);

            Instantiate(taxi, new Vector3(-1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(1.5f);

            Instantiate(bus, new Vector3(1.1f, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(1.5f);  
            
            Instantiate(car_2, new Vector3(-1, 0.2f, 30), new Quaternion(0, -180, 0, 0));
            yield return new WaitForSeconds(2.5f); 
            }
        }
    }
}
