using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botpaddle : MonoBehaviour
{
    // variables for bot baddle
    public float Speed = 5f;
    public string leftOrright;
    public float ySpeed;
    public float yPosition = 0f;

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
        if (leftOrright == "left") // looks for if the paddle is left or right if left do this
        {
            if (Input.GetKey(KeyCode.W)) // if w is pressed
            {
                transform.Translate(Vector3.up * Speed * Time.deltaTime); // go up

            }
            if (Input.GetKey(KeyCode.S)) // if s is pressed
            {
                transform.Translate(Vector3.down * Speed * Time.deltaTime); // go down

            }
            // left or right paddle
        }
        else if (leftOrright == "right") // if not left but right than do this
        {
            // bot script
            // ySpeed = Speed * Time.deltaTime;
            yPosition = yPosition + ySpeed * Time.deltaTime; // y position plus the yspeed * delta time means that the speed is the same in every game
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z); //calling for a new vector in which it can only go up or down
            if (yPosition >= 3.9f) // if the y position = 3.9 then go down
            {
                ySpeed = ySpeed * -1f; // speed times minus to revers the direction
            }
            else if (yPosition <= -3.9f) // if the y position = -3.9 then go up 
            {
                ySpeed = ySpeed * -1f; // speed times minus to revers the direction
            }
            
        }
    }
}



