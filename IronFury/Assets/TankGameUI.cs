using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//This class:
//  Show the Games title
//  Show 3..2..1..go
//  Upon player win
//  Show player + "Wins"
public class TankGameUI : MonoBehaviour
{
    public static float winnerFlag = -1; //Needs to be set by outside class
    public GameObject player1;
    public GameObject player2;
    private Vector2 p1Spawn;
    private Vector2 p2Spawn;
    private float p1Rot;
    private float p2Rot;
    public Rigidbody2D Blue;
    public Rigidbody2D Red;

    public Text UI;
    private string winText;
    private float[] countdown = {3, 2, 1};
    private string[] winnerOps = { "Blue Wins", "Red Wins" };
    public void Start()
    {
        //Set Player spawn points
        p1Spawn = Blue.position;
        p2Spawn = Red.position;
        //Start the game
        StartCoroutine("StartGame");
    }
    
    IEnumerator StartGame()
    {
        //Show Title for a few Seconds
        UI.text = "Iron Fury";
        yield return new WaitForSeconds(3f);
        //Show 3..2..1...Go
        for(int i = 0; i < 3; i++)
        {
            UI.text = countdown[i].ToString();
            yield return new WaitForSeconds(1f);
        }
        UI.text = "Go!";
        yield return new WaitForSeconds(1f);
        UI.text = "";
    }
    
    public void EndGame()
    {
        //See who is the winner
        DetermineWinner();
        //Show the blinking text of who's winner on screen
        StartCoroutine("ShowWinner");
        //Reset Players to OG positions
       // ResetBoard();
        //Restart Game
        //StartCoroutine("StartGame");
        
    }
    
    IEnumerator ShowWinner()
    {
        ResetBoard();
        int toggle = -1;
        //Show Blinking text of who won (toggles every 1/2 second for 5 seconds)
        for(int i = 0; i < 4; i++)
        {
            //Toggle Text appearance
            if(toggle < 0)
            {
                //Show text of who won
                UI.text = winText;
                toggle = 1;
            }
            else
            {
                toggle = -1;
            }
            yield return new WaitForSeconds(.5f);
        }
        Start();
    }
    
    public void ResetBoard()
    {
        Blue.position = p1Spawn;
        Blue.rotation = p1Rot;
        Red.position = p2Spawn;
        Red.rotation = p2Rot;
    }
    
    public void DetermineWinner()
    {
        if(winnerFlag == 1f)
        {
            //set winText to  text blue wins
            winText = winnerOps[0];
            winnerFlag = -1;
            Debug.Log("Red win");

        }
        else if(winnerFlag == 2f)
        {
            //set winText to text Red Wins
            winText = winnerOps[1];
            winnerFlag = -1;
            Debug.Log("Blue win");
        }
        else
        {
            Debug.Log("Error: No winnerflag set");
            //set winText to the stalemate text
        }
    }
    
    public void OnEnable()
    {
        Projectile.destroyAction += EndGame;
    }
    
    public void OnDisable()
    {
        Projectile.destroyAction -= EndGame;
    }
    
}