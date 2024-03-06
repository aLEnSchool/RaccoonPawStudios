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
    public string[] voiceLines;
    private int voiceLineIndex = 0;

    //Dialog Box Variables
    [Header("Dialog Variables",order =1)]
    public GameObject dialogBox;
    public GameObject dialogButton;
    public TextMeshProUGUI dialogOutput;
    
    private bool inRange;

    [Header("Typewriter Variables", order = 1)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        causingScene = false;
        inRange = false;

        //Voice Line Initialize
        //InitializeVoiceLines();
        //voiceLineIndex = 0;
        dialogBox.SetActive(false);

        EndCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                dialogBox.SetActive(true);
                //EndCheck();

                //If Scene was caused, Claye shall be eating allowing player to go through bag
                if (causingScene && Sadie.talkedToPlayer)
                {
                    voiceLineIndex = 4;
                    dialogButton.SetActive(false);
                }

                //Voice Line Output
                //Debug.Log(voiceLines[voiceLineIndex]);
                dialogOutput.text = voiceLines[voiceLineIndex];
                EndCheck();
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
    /* private void InitializeVoiceLines()
    {
        voiceLines = new string[5] {"I WANT FOOD!","GET ME FOOD","FOOOOOOOD!","food...", "NOM NOM NOM" };
    }*/

    //When button clicked, next dialog will show
    public void ContinueDialog()
    {
        //If on last voice line, repeat
        if (voiceLineIndex < 2)
        {
            voiceLineIndex++; //Next Voice Line
            //EndCheck();
        }
        if (voiceLineIndex == 2)
        {
            voiceLineIndex = 2;
            causingScene = true;
            dialogButton.SetActive(false);
        }

        EndCheck();
        dialogOutput.text = voiceLines[voiceLineIndex];
    }
    public void EndCheck()
    {
        if (i <= voiceLineIndex)
        {
            dialogOutput.text = voiceLines[voiceLineIndex];
            StartCoroutine(TextVisible());
        }
    }

    //Typewriter effect for dialog shown
    private IEnumerator TextVisible()
    {
        //dialogOutput = voiceLines[voiceLineIndex];
        dialogOutput.ForceMeshUpdate();
        int totalVisibleCharacters = dialogOutput.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            dialogOutput.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);
        }
    }
}
