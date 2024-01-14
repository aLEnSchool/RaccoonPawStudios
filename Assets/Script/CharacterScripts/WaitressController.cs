using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitressController : MonoBehaviour
{
    public Customer3Controller claye;
    public bool cookBusy;
    public bool talkedToPlayer;

    //Voice Lines Variables
    private string[] voiceLines;
    private int voiceLineIndex;

    //Dialog Box Variables
    public GameObject dialogBox;
    public TMP_Text dialogOutput;

    private bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        cookBusy = false;
        talkedToPlayer = false;

        inRange = false;

        InitializeVoiceLines();
        voiceLineIndex = 0;
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log(voiceLines[voiceLineIndex]);

                //If claye is causing a scene, cook will be busy; allowing player to enter kitchen
                if (claye.causingScene)
                {
                    voiceLineIndex = 2;
                    talkedToPlayer = true;
                    cookBusy = true;
                }
                else
                {
                    voiceLineIndex = 0;
                }

                //Voice Line Output
                dialogBox.SetActive(true);
                dialogOutput.text = voiceLines[voiceLineIndex];
            }
        }
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
            Debug.Log(voiceLines[1]);
            dialogBox.SetActive(false);
        }
    }

    /*-- Functions --*/
    private void InitializeVoiceLines()
    {
        voiceLines = new string[3] { "Hi, would you like anything?", "Okay... Bye!", "Oh Let me tend to this customer" };
    }

    /*
    //Waitress Getting Claye's Order Event
    private void GettingClayesOrder() 
    {

    }*/
}
