using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject limb;
    // public Vector3 origin = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        // Fuckin Jank way to spawn in 5 limbs at random locations
        Vector2 position1 = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject Limb1 = Instantiate(limb, position1, Quaternion.identity);
        Vector2 position2 = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject Limb2 = Instantiate(limb, position2, Quaternion.identity);
        Vector2 position3 = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject Limb3 = Instantiate(limb, position3, Quaternion.identity);
        Vector2 position4 = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject Limb4 = Instantiate(limb, position4, Quaternion.identity);
        Vector2 position5 = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
        GameObject Limb5 = Instantiate(limb, position5, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
