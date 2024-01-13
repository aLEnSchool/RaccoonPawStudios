using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private bool objectPickedUp;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        objectPickedUp = false;
        inRange = false;
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
            else if (objectPickedUp)
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
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
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
