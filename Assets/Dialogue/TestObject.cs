using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    private bool inRange;

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
                itemEvent();
                pickUp();
            }
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
    }

    private void itemEvent()
    {
        PlayerDataController.instance.itemTest = true;
    }
}
