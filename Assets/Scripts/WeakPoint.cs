using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    // vector2 of Ints for tracking XY position
    private Vector2Int gridPosition;

    public Tilemap WeakpointMap;

    public bool wkptShift = false;
    private void Awake()
    {
        gridPosition = new Vector2Int(0, -3);
    }

    // Update is called once per frame
    // idea every: 3 secs, the (x,y) pos of wkpt changes randomly
    private void Update()
    {
        // first starfish is done moving and then weakpoint changes place
        if(Turnmaster.done1 && !wkptShift){
            gridPosition.x = Random.Range(-3,4);
            gridPosition.y = Random.Range(-3,4);
            wkptShift = true;
        }
    }
}
