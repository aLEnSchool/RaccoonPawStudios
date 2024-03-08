using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaitressController : MonoBehaviour
{

    //Event Variables
    public Customer3Controller claye;
    public bool cookBusy;
    public bool talkedToPlayer;

    //Voice Lines Variables
    public string[] voiceLines;
    private int voiceLineIndex;

    //Dialog Box Variables
    [Header("Dialog Variables", order = 1)]
    public GameObject dialogBox;
    public TMP_Text dialogOutput;
    //public GameObject dialogButton;

    [Header("Typewriter Variables", order = 2)]
    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
    int i = 0;

    private bool inRange;


    // Start is called before the first frame update
    void Start()
    {
        cookBusy = false;
        talkedToPlayer = false;

        inRange = false;

        dialogOutput.text = voiceLines[voiceLineIndex];

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
               // Debug.Log(voiceLines[voiceLineIndex]);
                dialogBox.SetActive(true);

                //If claye is causing a scene, cook will be busy; allowing player to enter kitchen
                if (claye.causingScene)
                {
                    //dialogButton.SetActive(false);
                    voiceLineIndex = 2;
                    talkedToPlayer = true;
                    cookBusy = true;
                }
                else
                {
                    voiceLineIndex = 0;
                    //dialogButton.SetActive(false);
                }

                //Voice Line Output
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
            Debug.Log(voiceLines[1]);
            dialogBox.SetActive(false);
        }
    }

    /*-- Functions --*/
    /*private void InitializeVoiceLines()
    {
        voiceLines = new string[3] { "Hi, I'm waiting to see if anyone needs anything", "Okay... Bye!", "Oh Let me tend to this customer!" };
    }*/

    //When button clicked, next dialog will show
    public void ContinueDialog()
    {
        //If claye is causing a scene, cook will be busy; allowing player to enter kitchen
        if (claye.causingScene)
        {
            //dialogButton.SetActive(false);
            voiceLineIndex = 2;
            talkedToPlayer = true;
            cookBusy = true;
        }
        else
        {
            voiceLineIndex = 0;
            //dialogButton.SetActive(false);
        }

        //Voice Line Output
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
