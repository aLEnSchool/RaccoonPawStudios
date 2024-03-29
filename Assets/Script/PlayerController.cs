using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Movement Variables")]
    [SerializeField] private float moveSpeed = 9f;
    [SerializeField] private float rollSpeed = 0.2f;
    [SerializeField] private float jumpForce = 10f;

    private float inputX;
    private Rigidbody2D rb;
    public bool canMove;

    private bool jumping = false;   // check whether the player has jumped
    private int jumpCount = 0;      // counter for double jump

    // jumping on the bench
    [SerializeField] private float jumpForceBench = 5f;
    private bool jumpingBench = false;   // check whether the player has jumped
    private int jumpCountBench = 0;      // counter for double jump
    private bool fromFloor = true;

    [Header("Animation")]
    [SerializeField] public Animator animator;
    private bool playHatAnimation = false; // variable to check if the hat floating down animation has been played or not
    private bool facingRight = true;   // check which direction the player is facing

    [Header("Audio Source")]
    [SerializeField] private AudioSource playerSwoosh;
    private bool playSound = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        inputX = 0;
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        // sprite animations
        if ((inputX > 0.01 || inputX < -0.01) && !jumping)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }


        if (!jumping && fromFloor)
        {
            inputX = 0;
        }

        if (canMove)
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

            //Play Sound
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                playerSwoosh.Play();
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                playerSwoosh.Play();
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                playerSwoosh.Stop();
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                playerSwoosh.Stop();
            }

            // jumping on floor
            if ((Input.GetKeyDown(KeyCode.W) && (!jumping)) || Input.GetKeyDown(KeyCode.UpArrow) && (!jumping) || Input.GetKeyDown(KeyCode.Space) && (!jumping))
            {
                //playerSwoosh.Play();
                if (!fromFloor) // jumping off the bench
                {
                    rb.AddForce(Vector2.up * jumpForceBench, ForceMode2D.Impulse);
                }
                else // jumping off the floor
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }


                jumpCount += 1;
                jumping = checkJump(1); // check how many jumps have been done

                playHatAnimation = true; // allow the hat floating down animation to be played
            }

            if (Input.GetKeyUp(KeyCode.A) && jumping)
            {
                //Debug.Log("ADDING FORCE");
                rb.AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);

            }
            if (Input.GetKeyUp(KeyCode.D) && jumping)
            {
                //Debug.Log("ADDING FORCE");
                rb.AddForce(new Vector2(5f, 0f), ForceMode2D.Impulse);

            }
        }

        if (Input.GetKeyUp(KeyCode.A) && !jumping || Input.GetKeyUp(KeyCode.LeftArrow) && !jumping)
        {
            inputX = 0;
        }
        if (Input.GetKeyUp(KeyCode.D) && !jumping || Input.GetKeyUp(KeyCode.RightArrow) && !jumping)
        {
            inputX = 0;
        }

        // jumping on bench
        if ((Input.GetKeyDown(KeyCode.W) && (!jumpingBench)) || Input.GetKeyDown(KeyCode.UpArrow) && (!jumpingBench))
        {
            rb.AddForce(Vector2.up * jumpForceBench, ForceMode2D.Impulse);

            jumpCountBench += 1;
            jumpingBench = checkJump(1); // check how many jumps have been done

            playHatAnimation = true; // allow the hat floating down animation to be played
        }

        //Movement
        rb.velocity = new Vector2(inputX, rb.velocity.y);

        // have the hat float down
        if (rb.velocity.y < 0 && playHatAnimation) // if the hat is moving downwards
        {
            StartCoroutine(hatFloatingDownAnimation());
            playHatAnimation = false;
        }


        // flip character graphic
        if (inputX > 0 && !facingRight) // if player is going right but graphic is facing left
        {
            flip();
            facingRight = true;
        }
        else if (inputX < 0 && facingRight) // if player is going left but facing right
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

            fromFloor = true; // jumped from floor
        }
        else if (collision.gameObject.tag == "Bench")
        {
            // reset jump variables
            jumping = false;
            jumpCount = 0;

            fromFloor = false; // jumped from bench
        }
    }

    // function to slowly decrease the speed at which the hat is falling, to be used after a jump
    private IEnumerator hatFloatingDownAnimation()
    {
        for (int i = 0; i < 10; i++)
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