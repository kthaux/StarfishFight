using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (this.GetComponent<SpriteRenderer>().enabled == true){
            //Destroy the limb if Object tagged Player comes in contact with it (collect the limb)
            if (c2d.CompareTag("Player"))
            {
                Debug.Log("ur stuck");
            }
        }
    }
}
