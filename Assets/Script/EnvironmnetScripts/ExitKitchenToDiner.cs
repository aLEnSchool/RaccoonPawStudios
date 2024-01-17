using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKitchenToDiner : MonoBehaviour
{
    private bool inRange;
    public bool exitRoom;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        exitRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Change camera to the next room
                exitRoom = true;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;

            // change colour when intersected
            //gameObject.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }
}
