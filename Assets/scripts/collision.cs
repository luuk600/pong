using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class collision : MonoBehaviour
{
    // all the variables are set here a float is a decimal number
    // a gameObject is an Object in a game
    // an int is a whole number
    // a string is text
    // TMP pro is is the text we use in unity
    // audio source is for being able to add audio 
    // public is so you can see it in unity 
    // private is so you dont have a long list of variables in unity
    public float Xposition = 0f;
    public float Yposition = 0f;
    public float Xspeed = 4f;
    public float Yspeed = 4f;
    private GameObject scoreGameObject;
    private TMPro.TMP_Text scoreText;
    private int player1Score;
    private int player2Score;
    private string p1won;
    private string p2won;
    private GameObject winner;
    private TMPro.TMP_Text winnerText;
    private GameObject botPaddle;
    AudioSource hitAudio;


    // Start is called before the first frame update
    void Start()
    {
        scoreGameObject = GameObject.Find("score"); // finds the GameObject score and says that it should be the same as the string scoreGameObject
        scoreText = scoreGameObject.GetComponent<TMPro.TMP_Text>(); // now it says that it should use the text writing box TMP
        winner = GameObject.Find("who-won");// this makes sure that you get a text at the end of the game saying who won
        winnerText = winner.GetComponent<TMPro.TMP_Text>(); // again this defines that it should put the text in the writing box assignt for it
        botPaddle = GameObject.Find("paddle right"); //this makes sure that we can reset the paddles to Yposition 0
        hitAudio = GetComponent<AudioSource>(); // this is used for audio


    }

    // Update is called once per frame
    void Update()
    {
        // isPaused
        Xposition += Xspeed * Time.deltaTime; // setting the speed of the ball equal in every game
        Yposition += Yspeed * Time.deltaTime; // setting the speed of the ball equal in every game
        transform.position = new Vector3(Yposition, Xposition, 0); // set starting x and y position for the ball

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalwall")) // this says search horizontal wall if found everything in here is used for the game
        {
            Debug.Log("toucht horizontal wall"); // putting text in the debug log saying it thoucht he horizontal wall
            // making the ball speedup
            Xspeed = Xspeed * -1.1f; // assinging the speeding of the ball
            hitAudio.Play();// plays the explosion sound
        }
        if (collision.gameObject.CompareTag("verticalwall")) // search verticalwall everything in here should be used for it
        {
            // scoreboard
            Xposition = 0; Yposition = 0; //defines starting position
            // which wall got hit?
            // update score variable
            // update score string
            // update canvas score  "player1score - pla
            player1Score ++; // the score of player 1 goes up by 1
            // speed reset after point
            Yspeed = 4f; // starting speed of the ball
            Xspeed = 4f; // starting speed of the ball
            resetPaddle(); // resetting the bot paddle
        }
        if (collision.gameObject.CompareTag("verticalwall2")) // searcht verticalwall2 and execute everything in here
        {
            // scoreboard
            Xposition =0; Yposition = 0; //defines starting position
            player2Score ++; // the score of player 2 goes up by 1
            // speed reset after point
            Yspeed = 4f; // starting speed of the ball
            Xspeed = 4f; // starting speed of the ball
            resetPaddle(); // resetting the bot paddle
        }
        if (collision.gameObject.CompareTag("paddle")) // search paddle and execute everything in here
        {
            Debug.Log("toucht vertical wall"); // put in the debug log touch vertical wall
            // making the ball speedup
            Yspeed = Yspeed * -1.1f; // making sure the ball speeds up

        }
        if (player1Score == 3)  // if the score of player 1 is 3 then play the text player 1 you won congratulations
        {
            p1won = "player 1 you won congratulations"; // assigning the text to the variable
            winnerText.text = p1won; // send the signal that the text player 1 won should be displayed on screen
            Yspeed = 0f; // speed of the ball = 0
            Xspeed = 0f; // speed of the ball = 0
            StartCoroutine(ExampleCoroutine()); // this ia a routine that is called to start

            
            
        }
        if (player2Score == 3) // is the score of player 2 is 3 than play the text of player 2 winning
        {
            p2won = "player 2 you won congratulations"; // the same as number 1 but with a 2
            winnerText.text = p2won; // send the signal that the text player 2 won should be displayed on screen
            Yspeed = 0f; // speed of the ball is set to 0
            Xspeed = 0f; // speed of the ball is set to 0
            StartCoroutine(ExampleCoroutine()); // starting the routine that makes the game pause for a bit before restarting the game so you can play again
        }


    }
    private void LateUpdate() // calling a private void called lateupdate
    {
        scoreText.text = player1Score.ToString() + " - " + player2Score.ToString();// making the text display
    }

    IEnumerator ExampleCoroutine() // the coroutine tine for pause
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time); // signaling that the coroutine has started

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5); //making the game wait for 3 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // looking for the scene so it can reload it

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time); // signaling that the coroutine has ended 
    }
    

    private void resetPaddle() // calling a private void called reset paddle
    {
        botPaddle.GetComponent<botpaddle>().yPosition = 0f; // making the bot paddle reset to yposition 0
    }
}
