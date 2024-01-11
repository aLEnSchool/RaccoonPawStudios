using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customer3Controller : MonoBehaviour
{
    //Voice Lines
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

                if (voiceLineIndex >= 2)
                {
                    voiceLineIndex = 2;
                }

                //Voice Line Output
                dialogBox.SetActive(true);
                dialogOutput.text = voiceLines[voiceLineIndex];

                voiceLineIndex++;
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
        inRange = false;
        Debug.Log(voiceLines[3]);
        dialogBox.SetActive(false);
    }

    private void InitializeVoiceLines()
    {
        voiceLines = new string[4] {"I WANT FOOD!","GET ME FOOD","FOOOOOOOD!","food..." };
    }
}
