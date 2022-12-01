using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
   //Keep track of total picked up limbs
    public static int totalLimbs = 0; 

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
            Debug.Log("You currently have " + LimbController.totalLimbs + " limbs.");
            //Destroy limb
            Destroy(gameObject);
        }
    }
}
