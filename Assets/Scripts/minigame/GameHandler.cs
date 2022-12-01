using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private GameObject go;

    public static bool minidone = true;

    public float timer = 5;

    void Start()
    {
        minidone = false;
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

        //initiate timer based off of legs
        timer = 10;

        //choose the appropriate starfish to spawn

        Debug.Log("chosen starfish was: " + Turnmaster.chosen);
        Vector2 spawnpos = new Vector2(0, 0);
        GameObject Starmini = Instantiate(starmini1, spawnpos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {

            minidone = true;
            SceneManager.UnloadSceneAsync(2);
        }
        timer -= Time.deltaTime;
        Debug.Log("Timer: " + timer);

    }
}
