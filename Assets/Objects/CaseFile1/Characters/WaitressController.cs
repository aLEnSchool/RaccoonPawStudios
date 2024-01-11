using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitressController : MonoBehaviour
{

    //VoiceLines
    private string[] voiceLines;
    private int voiceLineIndex;
    
    private bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        inRange = false;

        InitializeVoiceLines();
        voiceLineIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private void InitializeVoiceLines()
    {
        voiceLines = new string[4] { "I WANT FOOD!", "GET ME FOOD", "FOOOOOOOD!", "food..." };
    }
}
