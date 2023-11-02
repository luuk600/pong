using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inputPaddle : MonoBehaviour
{
    public float Speed = 5f; // speed of paddle
    public string leftOrright; // looking if the paddle is left or right
    public float Speedy = 5f; // speed of paddle

    // Start is called before the first frame update
    void Start()
    {
       
    }
    //void setKeyAndMovement(KeyCode up, KeyCode down) 
    //{
    //    if (Input.GetKey(up)) 
    //    {
    //        transform.Translate(Vector3.up * Speed * Time.deltaTime);
    //    }
    //    else if (Input.GetKey(down)) 
    //    {
    //        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        // function that calls movement and has variables for up and down
        if (leftOrright == "left") // if the paddle = left need to put that in unity then execute the orders below
        { 
            if (Input.GetKey(KeyCode.W)) // if the w key is pressed
            {
                transform.Translate(Vector3.up * Speed * Time.deltaTime); // go up
                
            }
            if (Input.GetKey(KeyCode.S)) // if the S key is pressed
            {
                transform.Translate(Vector3.down * Speed * Time.deltaTime); // go down 
              
            }
            // left or right paddle
        }else if (leftOrright == "right") // if the paddle = right than execute the lines below
        {
            if (Input.GetKey(KeyCode.UpArrow)) // if the uparrow key is pressed
            {
                transform.Translate(Vector3.up * Speed * Time.deltaTime); // go up

            }
            if (Input.GetKey(KeyCode.DownArrow)) // if the downarrow key is pressed
            {
                transform.Translate(Vector3.down * Speed * Time.deltaTime); // go down

            }
        }
        }
    }

