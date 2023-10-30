using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class botpaddle : MonoBehaviour
{

    public float Speed = 5f;
    public string leftOrright;
    public float ySpeed;
    public float yPosition = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void setKeyAndMovement(KeyCode up, KeyCode down)
    {
        if (Input.GetKey(up))
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
        else if (Input.GetKey(down))
        {
            transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // function that calls movement and has variables for up and down
        if (leftOrright == "left")
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * Speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * Speed * Time.deltaTime);

            }
            // left or right paddle
        }
        else if (leftOrright == "right")
        {
            //ySpeed = Speed * Time.deltaTime;
            yPosition = yPosition + ySpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
            if (yPosition >= 3.9f)
            {
                ySpeed = ySpeed * -1f;
            }
            else if (yPosition <= -3.9f)
            {
                ySpeed = ySpeed * -1f;
            }
            
        }
    }
}



