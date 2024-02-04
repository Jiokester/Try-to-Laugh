using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: [Ihejirika, Chijioke]
 * Last Updated: [02/03/2024]
 * [Controls the movement of the player]
 */
public class PlayerMovement : MonoBehaviour
{
    //handles speed
    private float speed = 5.0f;

    
    public Rigidbody playerRb;

   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

        //Movement happens here
        if (Input.GetKey(KeyCode.A))
        {
            //player moves left
            transform.position += Vector3.left * speed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.D))
        {
            //player moves right
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.W))
        {
            //player moves up
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //player moves down
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
     
    }
}
