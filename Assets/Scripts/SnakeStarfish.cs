using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class SnakeStarfish : MonoBehaviour
{
    // vector2(?) of ints for tracking XY position 
    private Vector2Int gridPosition;
    private Vector3Int targetPos;
    //int to keep return value of projMove
    private int projReturn;

    public Tilemap wallMap;

    private void Awake()
    {
        //initial position for the starfish to start at
        gridPosition = new Vector2Int(0, 0);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            projReturn = projMove(gridPosition, 1);
            if(projReturn == 0)
            {
                gridPosition.y += 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            projReturn = projMove(gridPosition, 3);
            if(projReturn == 0)
            {
                gridPosition.y -= 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            projReturn = projMove(gridPosition, 2);
            if(projReturn == 0)
            {
                gridPosition.x += 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            projReturn = projMove(gridPosition, 4);
            if(projReturn == 0)
            {
                gridPosition.x -= 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }

        
    }

    private int projMove(Vector2Int projVector, int direction)
    {
        targetPos.x = projVector.x;
        targetPos.y = projVector.y;
        targetPos.z = 0;

        //Debug.Log("Projecting");

        //up
        if(direction == 1)
        {
            Debug.Log("UP");
            targetPos.y += 1;
            if(wallMap.HasTile(targetPos))
            {
                Debug.Log("Tile found above");
                return 1;
            }
            else
            {
                Debug.Log("tile above is empty");
                return 0;
            }
        }
        //right
        if(direction == 2)
        {
            Debug.Log("RIGHT");
            targetPos.x += 1;
            if(wallMap.HasTile(targetPos))
            {
                Debug.Log("Tile found to the right");
                return 1;
            }
            else
            {
                Debug.Log("tile right is empty");
                return 0;
            }
        }
        //down
        if(direction == 3)
        {
            Debug.Log("DOWN");
            targetPos.y -= 1;
            if(wallMap.HasTile(targetPos))
            {
                Debug.Log("Tile found below");
                return 1;
            }
            else
            {
                Debug.Log("tile below is empty");
                return 0;
            }
        }
        //left
        if(direction == 4)
        {
            Debug.Log("LEFT");
            targetPos.x -= 1;
            if(wallMap.HasTile(targetPos))
            {
                Debug.Log("Tile found to the left");
                return 1;
            }
            else
            {
                Debug.Log("tile left is empty");
                return 0;
            }
        }

        return 0;
    }
}
