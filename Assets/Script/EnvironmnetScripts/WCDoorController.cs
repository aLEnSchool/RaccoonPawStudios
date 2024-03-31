using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCDoorController : MonoBehaviour
{
    private bool inRange;
    public bool exitRoom;
    private bool knobInDoor;

    [Header("Ink Files")]
    [SerializeField] private TextAsset dialogFile1;

    [SerializeField] private GameObject doorWithKnob;
    [SerializeField] private GameObject doorNoKnob;
    [SerializeField] private GameObject doorknob;

    GameObject blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        exitRoom = false;
        knobInDoor = false;

        doorWithKnob.SetActive(false);
        doorNoKnob.SetActive(true);

        blackScreen = GameObject.FindWithTag("BlackScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !DialogueManager.GetInstance().dialogueIsPlaying) // if player is in range of the door
        {
            if (Input.GetKeyDown(KeyCode.F) && !(blackScreen.GetComponent<FadeToBlack>().isSwitchingRooms)) // if user presses E, and not in the middle of switching rooms
            {
                if (knobInDoor) // if player brought missing doorknob to door
                {
                    // Change camera to the next room
                    exitRoom = true;
                }
                else
                {
                    DialogueManager.GetInstance().EnterDialogueMode(dialogFile1);
                    // display "cannot enter" message
                    Debug.Log("cannot enter, there is no doorknob");
                }
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

        if(collision.gameObject.tag == "Doorknob"){
            knobInDoor = true;

            // put knob back in door
            doorWithKnob.SetActive(true);
            doorNoKnob.SetActive(false);
            doorknob.SetActive(false);
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
