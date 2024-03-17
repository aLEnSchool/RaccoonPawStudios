using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class TestObject : MonoBehaviour
{
    private bool inRange;
    public 

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pickUp();
            }
        }
        if (PlayerDataController.instance.itemTest)
        {
            Debug.Log("Item has once been picked up");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player ENter");
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Player Exit");
            inRange = false;
        }
    }

    private void pickUp()
    {
        Debug.Log("Item PickedUp");
        PlayerDataController.instance.itemTest = true;
    }


}
