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
    public int type = 0;

    public Tilemap wallMap;
    public Tilemap wkptMap;

    public int moves;
    public int dmg;
    public int time;
    public int Mlegs;
    public int YLegs;
    public int Clegs;

    public bool isTurn = false;

    private void Awake()
    {
        //initial position for the starfish to start at
        if(type == 1)
        {
            gridPosition = new Vector2Int(-1, 0);
        }
        else if(type == 2)
        {
            gridPosition = new Vector2Int(0, 0);
        }
        else
        {
            gridPosition = new Vector2Int(1, 0);
        }


        //initialize move count based on limbs
        moves = 5; // (Clegs + Mlegs + (2 * Ylegs))

        dmg = 5; // (CLegs + Ylegs + (2 * Mlegs))

        time = 10; // (5 + Mlegs + Ylegs + (2* Clegs))
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isTurn)
        {
            
            projReturn = projMove(gridPosition, 1);
            //are we hitting a wall? if not, move
            if(projReturn == 0 && moves > 0)
            {
                gridPosition.y += 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                moves -= 1;
            }
            //are we hitting a weakpoint
            else if(projReturn == 2 && moves > 0)
            {
                //apply dmg here
                Debug.Log("Weakpoint hit. applying dmg");
                moves = 0;
            }
            //we hit a wall. dont move, dont decrement moves
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isTurn)
        {

            projReturn = projMove(gridPosition, 3);
            if(projReturn == 0 && moves > 0)
            {
                gridPosition.y -= 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                moves -= 1;
            }
            else if(projReturn == 2 && moves > 0)
            {
                //apply dmg here
                Debug.Log("Weakpoint hit. applying dmg");
                moves = 0;
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && isTurn)
        {
            projReturn = projMove(gridPosition, 2);
            if(projReturn == 0 && moves > 0)
            {
                gridPosition.x += 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                moves -= 1;
            }
            else if(projReturn == 2 && moves > 0)
            {
                //apply dmg here
                Debug.Log("Weakpoint hit. applying dmg");
                moves = 0;
            }
            else
            {
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isTurn)
        {

            projReturn = projMove(gridPosition, 4);
            if(projReturn == 0 && moves > 0)
            {
                gridPosition.x -= 1;
                transform.position = new Vector3(gridPosition.x, gridPosition.y);
                moves -= 1;
            }
            else if(projReturn == 2 && moves > 0)
            {
                //apply dmg here
                Debug.Log("Weakpoint hit. applying dmg");
                moves = 0;
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
            //Debug.Log("UP");
            targetPos.y += 1;
            if(wallMap.HasTile(targetPos))
            {
                //Debug.Log("Tile found above");
                return 1;
            }
            else if(wkptMap.HasTile(targetPos))
            {
                return 2;
            }
            else
            {
                //Debug.Log("tile above is empty");
                return 0;
            }
        }
        //right
        if(direction == 2)
        {
            //Debug.Log("RIGHT");
            targetPos.x += 1;
            if(wallMap.HasTile(targetPos))
            {
                //Debug.Log("Tile found to the right");
                return 1;
            }
            else if(wkptMap.HasTile(targetPos))
            {
                return 2;
            }
            else
            {
                //Debug.Log("tile right is empty");
                return 0;
            }
        }
        //down
        if(direction == 3)
        {
            //Debug.Log("DOWN");
            targetPos.y -= 1;
            if(wallMap.HasTile(targetPos))
            {
                //Debug.Log("Tile found below");
                return 1;
            }
            else if(wkptMap.HasTile(targetPos))
            {
                return 2;
            }
            else
            {
                //Debug.Log("tile below is empty");
                return 0;
            }
        }
        //left
        if(direction == 4)
        {
            //Debug.Log("LEFT");
            targetPos.x -= 1;
            if(wallMap.HasTile(targetPos))
            {
                //Debug.Log("Tile found to the left");
                return 1;
            }
            else if(wkptMap.HasTile(targetPos))
            {
                return 2;
            }
            else
            {
                //Debug.Log("tile left is empty");
                return 0;
            }
        }

        return 0;
    }

    public int getMoves()
    {
        return moves;
    }

    public void setMoves(int newMoves)
    {
        moves = newMoves;
    }

    public void setTurn(bool turn)
    {
        isTurn = turn;
    }

    public bool getTurn()
    {
        return isTurn;
    }

    public void updateLegs()
    {
        
    }

}

