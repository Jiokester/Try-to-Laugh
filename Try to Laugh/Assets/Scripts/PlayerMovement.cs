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

    private float horizontal;
    private float vertical;

    Vector2 movement;
    public Rigidbody2D playerRb;

   

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
     //Movement happens here
     playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);
    }
}
