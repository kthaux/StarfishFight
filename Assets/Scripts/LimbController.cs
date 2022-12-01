using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
   //Keep track of total picked up limbs
    public static int totalLimbs = 0; 
    public bool collected = false;
    public Vector2 speed = new Vector2(10, 10);

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the limb if Object tagged Player comes in contact with it (collect the limb)
        if (c2d.CompareTag("Player"))
        {
            //Add limb to counter
            totalLimbs++;
            //Test: Print total number of limbs
            Debug.Log("You collected: " + this);
            Debug.Log("You currently have " + LimbController.totalLimbs + " limbs.");
            //Destroy limb
            // Destroy(gameObject);
            // transform.Translate(c2d.position);
            this.collected = true;
        }
    }

    void Update()
    {
        // Sets the limb to move at the same rate as the body, effectivly "combining" them
       if (collected) {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

            movement *= Time.deltaTime;

            transform.Translate(movement);
       } 
    }
}
