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

    //game objects for enemy sprites
    public GameObject eyeObst;
    public GameObject boneObst;
    public GameObject skullObst;
    public GameObject eyeStaticObst;
    public GameObject boneStaticObst;
    public GameObject skullStaticObst;
    GameObject eyeObst1;
    GameObject boneObst1;
    GameObject skullObst1;
    GameObject eyeStaticObst1;
    GameObject boneStaticObst1;
    GameObject skullStaticObst1;
    Vector2 eyeStaticObstPos;
    Vector2 boneStaticObstPos;
    Vector2 skullStaticObstPos;
    Vector2 eyeObstPos;
    Vector2 boneObstPos;
    Vector2 skullObstPos;
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

        // Spawn static enemy sprites in
        eyeStaticObstPos = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        eyeStaticObst1 = Instantiate(eyeStaticObst, eyeStaticObstPos, Quaternion.identity);
        eyeStaticObst1.GetComponent<SpriteRenderer>().enabled = false;
        boneStaticObstPos = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        boneStaticObst1 = Instantiate(boneStaticObst, boneStaticObstPos, Quaternion.identity);
        boneStaticObst1.GetComponent<SpriteRenderer>().enabled = false;
        skullStaticObstPos = new Vector2(Random.Range(-9, 9), Random.Range(-9, 9));
        skullStaticObst1 = Instantiate(skullStaticObst, skullStaticObstPos, Quaternion.identity);
        skullStaticObst1.GetComponent<SpriteRenderer>().enabled = false;

        // Spawn moving enemy sprites in
        eyeObstPos = new Vector2(-25, Random.Range(-9, 9));
        eyeObst1 = Instantiate(eyeObst, eyeObstPos, Quaternion.identity);
        boneObstPos = new Vector2(Random.Range(-9, 9), -15);
        boneObst1 = Instantiate(boneObst, boneObstPos, Quaternion.identity);
        skullObstPos = new Vector2(25, Random.Range(-9, 9));
        skullObst1 = Instantiate(skullObst, skullObstPos, Quaternion.identity);
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

        // Makes projectiles fly in at beginning
        if(Vector3.Distance(eyeObst1.transform.position, eyeStaticObst1.transform.position) > 0.8f){
            eyeObst1.transform.position = Vector2.Lerp(eyeObst1.transform.position, eyeStaticObstPos, .04f);
        } else {
            eyeStaticObst1.GetComponent<SpriteRenderer>().enabled = true;
            eyeObst1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(Vector3.Distance(boneObst1.transform.position, boneStaticObst1.transform.position) > 0.8f){
            boneObst1.transform.position = Vector2.Lerp(boneObst1.transform.position, boneStaticObstPos, .04f);
        } else {
            boneStaticObst1.GetComponent<SpriteRenderer>().enabled = true;
            boneObst1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(Vector3.Distance(skullObst1.transform.position, skullStaticObst1.transform.position) > 0.8f){
            skullObst1.transform.position = Vector2.Lerp(skullObst1.transform.position, skullStaticObstPos, .04f);
        } else {
            skullStaticObst1.GetComponent<SpriteRenderer>().enabled = true;
            skullObst1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(timer <= 0)
        {

            minidone = true;
            SceneManager.UnloadSceneAsync(2);
        }
        timer -= Time.deltaTime;
        // Debug.Log("Timer: " + timer);

    }
}
