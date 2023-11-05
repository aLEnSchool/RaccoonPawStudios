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

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        }

        //Movement
        Vector2 movementX = new Vector2(inputX, 0.0f); 
        movementX = movementX *Time.deltaTime;
        transform.Translate(movementX);
        //transform.position += new Vector3(inputX, 0f, 0f);
        inputX = 0f;
    }
}
