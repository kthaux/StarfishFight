using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    //Creates the base leftLimb prefab
    public GameObject leftLimb;
    public GameObject topLimb;
    public GameObject rightLimb;
    public GameObject botLeftLimb;
    public GameObject botRightLimb;

    //game objects to hold the starfish base
    public GameObject starmini1;
    public GameObject starmini2;
    public GameObject starmini3;

    void Start()
    {
        // Fuckin Jank way to spawn in 5 limbs at random locations
        Vector2 position1 = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        GameObject Limb1 = Instantiate(leftLimb, position1, Quaternion.identity);
        Vector2 position2 = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        GameObject Limb2 = Instantiate(topLimb, position2, Quaternion.identity);
        Vector2 position3 = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        GameObject Limb3 = Instantiate(rightLimb, position3, Quaternion.identity);
        Vector2 position4 = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        GameObject Limb4 = Instantiate(botLeftLimb, position4, Quaternion.identity);
        Vector2 position5 = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        GameObject Limb5 = Instantiate(botRightLimb, position5, Quaternion.identity);


        //choose the appropriate starfish to spawn

        Debug.Log("chosen starfish was: " + Turnmaster.chosen);
        Vector2 spawnpos = new Vector2(0, 0);
        GameObject Starmini = Instantiate(starmini1, spawnpos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
