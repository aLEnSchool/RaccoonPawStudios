using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customer3Controller : MonoBehaviour
{
    public WaitressController Sadie;    

    //Bool Variables
    public bool causingScene;

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
        causingScene = false;
        inRange = false;

        //Voice Line Initialize
        InitializeVoiceLines();
        voiceLineIndex = -1;
        dialogBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                

                //If on last voice line, repeat
                if (voiceLineIndex < 2)
                {
                    voiceLineIndex++; //Next Voice Line
                }
                if (voiceLineIndex == 2)
                {
                    voiceLineIndex = 2;
                    causingScene = true;
                }
                //If Scene was caused, Claye shall be eating allowing player to go through bag
                if (causingScene && Sadie.talkedToPlayer)
                {
                    voiceLineIndex = 4;
                }

                //Voice Line Output
                Debug.Log(voiceLines[voiceLineIndex]);
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
            Debug.Log(voiceLines[3]);
            dialogBox.SetActive(false);
        }
    }

    /*-- Functions --*/
    private void InitializeVoiceLines()
    {
        voiceLines = new string[5] {"I WANT FOOD!","GET ME FOOD","FOOOOOOOD!","food...", "nom nom nom" };
    }
}
