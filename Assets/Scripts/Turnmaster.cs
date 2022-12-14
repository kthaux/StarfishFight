using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turnmaster : MonoBehaviour
{
    public GameObject starfish1;
    public GameObject starfish2;
    public GameObject starfish3;

    public GameObject parent;

    public GameObject legY;
    public GameObject legC;
    public GameObject legM;

    public int turns1;
    public int turns2;
    public int turns3;

    public static bool done1; // changed to static to access for weakpoint map
    public bool done2;
    public bool done3;

    private SnakeStarfish comp1;
    private SnakeStarfish comp2;
    private SnakeStarfish comp3;

    //save who is going into the minigame
    private int minigamer;

    //static value to pass between scenes
    public static int chosen;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Turnmaster.Start");

        starfish1 = GameObject.Find("Starfish1");
        comp1 = starfish1.GetComponent<SnakeStarfish>();
        turns1 = comp1.getMoves();
        comp1.setTurn(true);
        Debug.Log("moves: " + turns1);

        starfish2 = GameObject.Find("Starfish2");
        comp2 = starfish2.GetComponent<SnakeStarfish>();
        turns2 = comp2.getMoves();
        Debug.Log("moves: " + turns2);

        starfish3 = GameObject.Find("Starfish3");
        comp3 = starfish3.GetComponent<SnakeStarfish>();
        turns3 = comp3.getMoves();
        Debug.Log("moves: " + turns3);
        
    }

    // Update is called once per frame
    void Update()
    {
        //return from minigame
        if(GameHandler.minidone == true)
        {
            parent.SetActive(true);
        }
        
        
        turns1 = comp1.getMoves();
        turns2 = comp2.getMoves();
        turns3 = comp3.getMoves();

        if(!done1 && !done2 && !done3)
        {
            //start of new round, beggining with starfish1

            comp1.setTurn(true);
        }

        //if any starfish have no moves left end their turn and update our flag and start the next ones turn
        if(turns1 < 1)
        {
            comp1.setTurn(false);

            done1 = true;

            comp2.setTurn(true);

        }
        if(turns2 < 1)
        {
            comp2.setTurn(false);

            done2 = true;

            comp3.setTurn(true);
        }
        if(turns3 < 1)
        {
            comp3.setTurn(false);
            done3 = true;
        }



        //if all turns have been taken, move to monster turn/minigame
        //also need to check if monster is alive still
        if(done1 && done2 && done3)
        {
            Debug.Log("Starfish turns over. moving to minigame and resetting turns");

            minigamer = Random.Range(1, 4);
            Debug.Log("Starfish " + minigamer + " was chosen");
            chosen = minigamer;

            //load minigame scene then reset starfish turns
            done1 = false;
            done2 = false;
            done3 = false;

            SceneManager.LoadScene(2, LoadSceneMode.Additive);

            parent.SetActive(false);
            
            //need logic for calculating limb # to set next turn's moves
            comp1.setMoves(5);
            comp2.setMoves(5);
            comp3.setMoves(5);

            
        }

    }


    public void setDone(int starNum)
    {
        if(starNum == 1)
        {
            done1 = true;
        }

        if(starNum == 2)
        {
            done2 = true;
        }

        if(starNum == 3)
        {
            done3 = true;
        }
    }
}
