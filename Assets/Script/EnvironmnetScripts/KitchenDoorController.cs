using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KitchenDoorController : MonoBehaviour
{
    //public WaitressController Sadie;

    private bool inRange;
    public bool exitRoom;

    //private bool playerInRange;

    //private string voiceLine;

    //Dialog Variables
    //public GameObject dialogBox;
    //public TMP_Text dialogOutput;


    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        exitRoom = false;

        //dialogBox.SetActive(false);
        //voiceLine = "Can't come in here, it's restricted";
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerDataController.instance.sadieBusy == true)
        {
            //TP TO KITCHEN
            if (inRange)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    exitRoom = true;
                }
            }
        }
        //else
        //{
        //    if (inRange)
        //    {
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            dialogBox.SetActive(true);
        //            dialogOutput.text = voiceLine;
        //        }
        //    }
        //}
    }

    /*-- Trigger Events --*/
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
        
            //dialogBox.SetActive(false);
        }
    }
}
