using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private bool inRange;
    public bool exitRoom;

    GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        exitRoom = false;

        blackScreen = GameObject.FindWithTag("BlackScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) // if player is in range of the door
        {
            Debug.Log(PlayerController.instance.sadie);
            Debug.Log(PlayerController.instance.rosa);
            if (Input.GetKeyDown(KeyCode.E) && !(blackScreen.GetComponent<FadeToBlack>().isSwitchingRooms) && !PlayerController.instance.sadie && !PlayerController.instance.rosa) // if user presses f, and not in the middle of switching rooms
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
