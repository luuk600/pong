using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float Xposition = 0f;
    public float Yposition = 0f;
    public float Xspeed;
    public float Yspeed;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Yposition, Xposition, 0);
        Xspeed = 4f;
        Yspeed = 4f;

    }

    // Update is called once per frame
    void Update()
    {
        Xposition += Xspeed * Time.deltaTime;
        Yposition += Yspeed * Time.deltaTime;
        transform.position = new Vector3(Yposition, Xposition, 0);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("horizontalwall"))  
        {
            Debug.Log("toucht horizontal wall");
            Xspeed = Xspeed * -1;

        }
        if (collision.gameObject.CompareTag("verticalwall"))
        {
            Debug.Log("toucht vertical wall");
            Yspeed = Yspeed * -1;

        }
    }
}
