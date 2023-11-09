using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float rollSpeed = 0.2f;
    private float jumpForce = 10f;

    private float inputX;
    private Rigidbody2D rb;

    private bool jumping = false;   // check whether the player has jumped
    private int jumpCount = 0;      // counter for double jump

    // Start is called before the first frame update
    void Start()
    {
        inputX = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            inputX = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputX = moveSpeed;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            inputX = 0;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            inputX = 0;
        }

        if ((Input.GetKeyDown(KeyCode.W) && (!jumping)) || Input.GetKeyDown(KeyCode.UpArrow) && (!jumping))
        {
            rb.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);

            jumpCount += 1;
            jumping = checkJump(1); // check how many jumps have been done
        }

        //Movement
        rb.velocity = new Vector2(inputX, rb.velocity.y);
    }

    // check if the player has jumped once
    // I have this as a function in case we want to include a double jump
    private bool checkJump(int maxJump)
    {
        if (jumpCount >= maxJump)
        {
            return true;
        }
        return false;
    }

    // check if the player has collided with the floor
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // if collided, allow the player to jump again
        if (collision.gameObject.tag == "Floor")
        {
            // reset jump variables
            jumping = false;
            jumpCount = 0;
        }
    }
}
