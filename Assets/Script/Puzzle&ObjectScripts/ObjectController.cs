using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private SpriteRenderer sprite; // For Testing

    private bool objectPickedUp;
    private bool inRange;
    private bool doorRange;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        objectPickedUp = false;
        inRange = false;
        doorRange = false;
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

        //Lantern Gets Clue collision
        if (transform.tag == "Lantern")
        {
            if (collision.transform.tag == "Glue")
            {
                transform.tag = "Lantern With Glue";
                sprite.color = Color.red;
            }
        }
        //Lantern Gets lit
        if (transform.tag == "Lantern With Glue")
        {
            if (collision.transform.tag == "Lighter")
            {
                transform.tag = "Lit Lantern";
                sprite.color = Color.yellow;
            }
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
    }

    private void dropItem()
    {
        Debug.Log("Dropping Item");
        objectPickedUp = false;
        inRange = false;

        GameObject restingPlace = GameObject.FindGameObjectWithTag("Rest");
        transform.SetParent(restingPlace.transform);
    }
}
