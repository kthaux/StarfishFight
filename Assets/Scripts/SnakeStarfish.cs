using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStarfish : MonoBehaviour
{
    // vector2(?) of ints for tracking XY position 
    private Vector2Int gridPosition;

    // centers the snake/starfish 
    // will likely change this to be near the bottom
    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
    }

    /* movement of the snake starfish by pressing the arrow keys
        Will need a check to see if player moves into enemy
        something like this, in scenario player moves right into enemy
        EX:
            this.gridPositon.x +=1;
            if(this.gridPosition == enemy.gridPosition)
                enemyHealth--;
                this.gridPosition-= 1;
                 
    */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridPosition.y += 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridPosition.y -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridPosition.x += 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridPosition.x -= 1;
        }

        transform.position = new Vector3(gridPosition.x, gridPosition.y);
    }
}
