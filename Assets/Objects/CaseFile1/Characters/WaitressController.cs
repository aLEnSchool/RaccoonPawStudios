using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitressController : MonoBehaviour
{

    //VoiceLines
    private string[] voiceLines;
    private int voiceLineIndex;
    public GameObject dialogBox;
    public TMP_Text dialogOutput;

    private bool inRange;


    // Start is called before the first frame update
    void Start()
    {
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
        inRange = false;
    }

    /*-- Functions --*/
    private void InitializeVoiceLines()
    {
        voiceLines = new string[1] { "Hi, would you like anything?"};
    }
}
