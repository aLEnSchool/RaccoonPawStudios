using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private SpriteRenderer sprite; // For Testing
    [SerializeField] private GameObject unlitLantern;
    [SerializeField] private GameObject litLantern;

    private bool objectPickedUp;
    private bool inRange;
    private bool doorRange;
    private bool objectOnGround; // to make object fall to the ground
    private bool objectDropped;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        objectPickedUp = false;
        inRange = false;
        doorRange = false;
        objectOnGround = true;
        objectDropped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (inRange) { 
                if (!objectPickedUp)
                {
                    pickUp();
                }
            }
            else if (objectPickedUp && !doorRange)
            {
                dropItem();
            }
        }
    }

    // make object fall to the ground once it's dropped
    private void FixedUpdate()
    {
        if (!objectOnGround)
        {
            //gameObject.transform.position += new Vector3(0, -0.08f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
        if (collision.gameObject.tag == "Door")
        {
            doorRange = true;
        }

        //Lantern Gets lit
        if (transform.tag == "Lantern")
        {
            if (collision.transform.tag == "Lighter")
            {
                transform.tag = "Lit Lantern";

                litLantern.SetActive(true);
                unlitLantern.SetActive(false);
            }
        }

        if (collision.gameObject.tag == "Floor")
        {
            objectOnGround = true;
            Debug.Log("OBJECT ON GROUND");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
        if (collision.gameObject.tag == "Door")
        {
            doorRange = false;
        }
    }

    private void pickUp()
    {
        Debug.Log("Object Picked Up");
        objectPickedUp = true;
        inRange = true;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(player.transform);
        transform.position = new Vector2(player.transform.position.x+1.5f, player.transform.position.y);

        objectDropped = false;
    }

    private void dropItem()
    {
        Debug.Log("Dropping Item");
        objectPickedUp = false;
        inRange = false;

        GameObject restingPlace = GameObject.FindGameObjectWithTag("Rest");
        transform.SetParent(restingPlace.transform);

        objectOnGround = false;
        objectDropped = true;
    }
}
