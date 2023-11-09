using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float rollSpeed = 0.2f;
    public float jumpForce = 10f;

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
        if (Input.GetKey(KeyCode.A))
        {
            inputX = -moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX = moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.W) && (!jumping))
        {
            rb.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);

            jumpCount += 1;
            jumping = checkJump(1); // check how many jumps have been done
        }

        //Movement
        Vector2 movementX = new Vector2(inputX, 0.0f); 
        movementX = movementX *Time.deltaTime;
        transform.Translate(movementX);
        //transform.position += new Vector3(inputX, 0f, 0f);
        inputX = 0f;
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
