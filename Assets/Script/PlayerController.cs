using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rollSpeed = 0.2f;
    [SerializeField] private float jumpForce = 10f;

    private float inputX;
    private Rigidbody2D rb;

    float horiMove = 0f;
    private bool jumping = false;   // check whether the player has jumped
    private int jumpCount = 0;      // counter for double jump
    private bool facingRight = true;   // check which direction the player is facing

    private bool playHatAnimation = false; // variable to check if the hat floating down animation has been played or not

    public Animator animator;

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
            animator.SetFloat("Speed", moveSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            inputX = moveSpeed;
            animator.SetFloat("Speed", moveSpeed);
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

            playHatAnimation = true; // allow the hat floating down animation to be played
        }

        //Movement
        rb.velocity = new Vector2(inputX, rb.velocity.y);

        //horiMove = Input.GetAxisRaw("Horizontal") * 40f; 

        // have the hat float down
        if (rb.velocity.x == 0) // if the hat isn't
        {
            animator.SetFloat("Speed", 0);
        }

        // have the hat float down
        if (rb.velocity.y < 0 && playHatAnimation) // if the hat is moving downwards
        {
            StartCoroutine(hatFloatingDownAnimation());
            playHatAnimation = false;
        }


        // flip character graphic
        if(inputX > 0 && !facingRight) // if player is going right but graphic is facing left
        {
            flip();
            facingRight = true;
        }
        else if(inputX < 0 && facingRight) // if player is going left but facing right
        {
            flip();
            facingRight = false;
        }

        //**** code from my game dev group for movement below ****

        //float targetSpeed = horizontal * speed;                                                         //Get the desired desired velocity
        //float speedDif = targetSpeed - rb.velocity.x;                                                   //Get the difference between the current velocity and our desired velocity
        //float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;              //If the absolute value of the tharget speed is greater than 0.1 set accel rate to accel
        
        //float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);   //calculate the movement

        //rb.AddForce(movement * Vector2.right);
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

    // function to slowly decrease the speed at which the hat is falling, to be used after a jump
    private IEnumerator hatFloatingDownAnimation()
    {
        for(int i = 0; i < 10; i++)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 1.0f);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("coroutine called, y value: " + rb.velocity.y);
        }
    }

    private void flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
