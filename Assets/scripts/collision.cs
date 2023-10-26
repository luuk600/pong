using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class collision : MonoBehaviour
{
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


    // Start is called before the first frame update
    void Start()
    {
        scoreGameObject = GameObject.Find("score");
        scoreText = scoreGameObject.GetComponent<TMPro.TMP_Text>();
        winner = GameObject.Find("who-won");
        winnerText = winner.GetComponent<TMPro.TMP_Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // isPaused
        Xposition += Xspeed * Time.deltaTime;
        Yposition += Yspeed * Time.deltaTime;
        transform.position = new Vector3(Yposition, Xposition, 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalwall"))
        {
            Debug.Log("toucht horizontal wall");
            // making the ball speedup
            Xspeed = Xspeed * -1.1f;

        }
        if (collision.gameObject.CompareTag("verticalwall"))
        {
            // scoreboard
            Xposition = 0; Yposition = 0;
            // which wall got hit?
            // update score variable
            // update score string
            // update canvas score  "player1score - pla
            player1Score ++;
            // speed reset after point
            Yspeed = 4f;
            Xspeed = 4f;

        }
        if (collision.gameObject.CompareTag("verticalwall2"))
        {
            // scoreboard
            Xposition =0; Yposition = 0;
            player2Score ++;
            // speed reset after point
            Yspeed = 4f;
            Xspeed = 4f;
            
        }
        if (collision.gameObject.CompareTag("paddle"))
        {
            Debug.Log("toucht vertical wall");
            // making the ball speedup
            Yspeed = Yspeed * -1.1f;

        }
        if (player1Score == 3) 
        {
            p1won = "player 1 you won congratulations";
            winnerText.text = p1won;
            Yspeed = 0f;
            Xspeed = 0f;
            StartCoroutine(ExampleCoroutine());

            
            
        }
        if (player2Score == 3) 
        {
            p2won = "player 2 you won congratulations";
            winnerText.text = p2won;
            Yspeed = 0f;
            Xspeed = 0f;
            StartCoroutine(ExampleCoroutine());
        }


    }
    private void LateUpdate()
    {
        // making the text display
        scoreText.text = player1Score.ToString() + " - " + player2Score.ToString();
    }

    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
    IEnumerator yourmotherCoroutine() 
    {
        yield return new WaitForSeconds(5);
    }
}
